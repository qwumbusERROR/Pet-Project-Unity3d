using UnityEngine;
using System.Collections.Generic;
using VContainer.Unity;

public sealed class StateMachineMotion
{
    private readonly Dictionary<StateType, IState> _states = new(); 

    private IState _currentState;
    public object CurrentState => _currentState;

    public StateMachineMotion(IEnumerable<IState> states)
    {
        foreach (var state in states)
            _states[state.Id] = state;
    }

    public void Start(StateType startState)
    {
        _currentState = _states[startState];
        _currentState.Enter();
    }

    public void Update(float time)
    {
        StateType next = _currentState.Tickable(time);
        if (next == _currentState.Id) return;

        _currentState.Exit();
        _currentState = _states[next];
        _currentState.Enter();
    }
}
