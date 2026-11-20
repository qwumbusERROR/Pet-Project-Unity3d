using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PlayerMovement : ITickable, IStartable
{
    private readonly MovementStateMachine _machine;
    private readonly ReactiveVariable<Vector2> _input;

    public PlayerMovement(MovementStateMachine machine, [Key("Move")] ReactiveVariable<Vector2> input)
    {
        _machine = machine;
        _input = input;
    }

    public void Start() => _machine.Start(MovementStateId.Grounded);
    public void Tick() 
    {
        _machine.Tick(_input.Value, Time.deltaTime);
    }
}
