using UnityEngine;

public class GroundedState : IMovementState
{
    private readonly CharacterMotor _motor;
    private readonly MovementConfig _config;

    public GroundedState(CharacterMotor motor, MovementConfig config)
    {
        _motor = motor;
        _config = config;
    }

    public MovementStateId Id => MovementStateId.Grounded;

    public void Enter() { }
    public void Exit() { }

    public MovementStateId Tick(Vector2 input, float deltaTime)
    {
        var config = _config.GroundMoveSettings;
        Vector3 desired = _motor.ToWorldDirection(input) * config.WalkSpeed;
        
        _motor.MoveHorizontal(desired, config.Acceleration, config.Deceleration, deltaTime);
        _motor.Move(deltaTime);

        return Id;
    }
}