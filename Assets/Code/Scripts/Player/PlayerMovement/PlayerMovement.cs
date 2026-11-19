using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class PlayerMovement : VContainer.Unity.ITickable, VContainer.Unity.IStartable
{
    private readonly Dictionary<MovementStateId, IMovementState> _states;
    private readonly ReactiveVariable<Vector2> _input;
    private IMovementState _current;

    public PlayerMovement(CharacterMotor motor,MovementConfig config, [Key("Move")] ReactiveVariable<Vector2> input)
    {
        _input = input;
        _states = new Dictionary<MovementStateId, IMovementState>
        {
            [MovementStateId.Grounded] = new GroundedState(motor, config),
        };
    }

    public void Start()
    {
        _current = _states[MovementStateId.Grounded];
        _current.Enter();
    }

    public void Tick()
    {
        MovementStateId next = _current.Tick(_input.Value, Time.deltaTime);
        if (next == _current.Id) return;

        _current.Exit();
        _current = _states[next];
        _current.Enter();
    }
}
