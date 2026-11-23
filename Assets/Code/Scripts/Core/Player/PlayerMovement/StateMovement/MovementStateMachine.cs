using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine
{
    private readonly Dictionary<MovementStateId, IMovementState> _states = new();

    private IMovementState _current;

    public MovementStateMachine(IEnumerable<IMovementState> states)
    {
        foreach (var state in states)
            _states[state.Id] = state;
    }

    public void Start(MovementStateId initial)
    {
        _current = _states[initial];
        _current.Enter();
    }

    public void Tick(Vector2 input, float dt)
    {
        MovementStateId next = _current.Tick(input, dt);
        if (next == _current.Id) return;

        _current.Exit();
        _current = _states[next];
        _current.Enter();
    }
}
