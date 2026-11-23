using UnityEngine;
using VContainer;
using VContainer.Unity;
using Game.Input;

public class PlayerMovement : ITickable, IStartable
{
    private readonly MovementStateMachine _machine;
    private readonly IMoveInput _input;

    public PlayerMovement(MovementStateMachine machine, IMoveInput input)
    {
        _machine = machine;
        _input   = input;
    }

    public void Start() => _machine.Start(MovementStateId.Grounded);

    public void Tick()
    {
        _machine.Tick(_input.ReadValue(), Time.deltaTime);
    }
}
