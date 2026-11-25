using UnityEngine;
using System.Collections.Generic;
using System;
using VContainer.Unity;

public sealed class StateMachineMotion
{
    private readonly Dictionary<StateType, IState> _states = new(); 

    private IState _currentState;
    public object CurrentState => _currentState;

    public event System.Action<IState> StateChanged;

    public StateMachineMotion(IEnumerable<IState> states)
    {
        foreach (var state in states)
            _states[state.Id] = state;
    }

    public void Start(StateType startState)
    {
        ChangeState(startState);
    }

    public void ChangeState(StateType state)
    {
        if (_currentState != null && _currentState.Id == state)
            return;

        if (!_states.TryGetValue(state, out IState nextState))
        {
            throw new ArgumentException($"State {state} is not registered in StateMachine.");
        }

        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();
        
        StateChanged?.Invoke(_currentState);
    }

    public void Update(float deltaTime)
    {
        if (_currentState is null)
            return;

        StateType nextState = _currentState.Tickable(deltaTime);
        if (nextState != _currentState.Id)
        {
            ChangeState(nextState);
        }
    }
}
