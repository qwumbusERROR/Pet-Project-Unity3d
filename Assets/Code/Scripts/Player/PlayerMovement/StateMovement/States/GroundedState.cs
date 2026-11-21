using UnityEngine;

public class GroundedState : IMovementState
{
    private readonly CharacterMotor _motor;
    private readonly MovementConfig _config;
    private readonly IInputBoolProvider _jumpInput;

    public GroundedState(CharacterMotor motor, MovementConfig config, IInputBoolProvider jumpInput)
    {
        _motor = motor;
        _config = config;
        _jumpInput = jumpInput;
    }

    public MovementStateId Id => MovementStateId.Grounded;

    public void Enter() 
    {
        #if UNITY_EDITOR
            Debug.Log("Enter to grounded states");
        #endif
    }
    public void Exit() { }

    public MovementStateId Tick(Vector2 input, float deltaTime)
    {
        var config = _config.GroundMoveSettings;
        Vector3 desired = _motor.ToWorldDirection(input) * config.WalkSpeed;
        
        _motor.MoveHorizontal(desired, config.Acceleration, config.Deceleration, deltaTime);
        _motor.ApplyGravity(deltaTime);
        _motor.Move(deltaTime);

        if (_jumpInput.InputCallback.Value && _motor.Grounded.StandingOnGround)
        {
            _motor.Jump();

            _jumpInput.InputCallback.Value = false;
            return MovementStateId.Airborne;
        }

        if (_motor.Grounded.Falling && _motor.VerticalVelocity < 0f)
            return MovementStateId.Airborne;

        return Id;
    }
}