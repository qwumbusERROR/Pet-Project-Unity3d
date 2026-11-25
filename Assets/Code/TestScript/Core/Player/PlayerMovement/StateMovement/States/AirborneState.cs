using UnityEngine;

public class AirborneState : IMovementState
{
    private readonly CharacterMotor _motor;
    private readonly MovementConfig _config;

    public AirborneState(CharacterMotor motor, MovementConfig config)
    {
        _motor = motor;
        _config = config;
    }

    public MovementStateId Id => MovementStateId.Airborne;

    public void Enter() 
    {
        #if UNITY_EDITOR
            Debug.Log("Enter to arborne states");
        #endif
    }
    public void Exit() { }

    public MovementStateId Tick(Vector2 input, float deltaTime)
    {
        var groundConfig = _config.GroundMoveSettings;
        var verticalConfig = _config.VerticalMoveSettings;

        Vector3 desired = _motor.ToWorldDirection(input) * groundConfig.WalkSpeed * verticalConfig.AirControlMultiplier;
        _motor.MoveHorizontal(desired, groundConfig.Acceleration, groundConfig.Deceleration, deltaTime);
        _motor.ApplyGravity(deltaTime);
        _motor.Move(deltaTime);

        if (_motor.Grounded.StandingOnGround && _motor.VerticalVelocity <= 0f)
            return MovementStateId.Grounded;

        return Id;
    }
}
