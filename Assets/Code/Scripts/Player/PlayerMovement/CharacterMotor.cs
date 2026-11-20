using UnityEngine;

public class CharacterMotor
{
    private readonly CharacterController _controller;
    private readonly MovementConfig _config;
    private readonly LayerMask _groundMask;

    private Vector3 _horizontalVelocity;
    private float _verticalVelocity;

    public float VerticalVelocity => _verticalVelocity;
    public bool IsGrounded { get; private set; }

    public CharacterMotor(CharacterController controller, MovementConfig config, LayerMask groundMask)
    {
        _controller = controller;
        _config = config;
        _groundMask = groundMask;
    }

    public Vector3 ToWorldDirection(Vector2 input)
    {
        Vector3 direction = _controller.transform.right * input.x + _controller.transform.forward * input.y;
        return direction.sqrMagnitude > 1f ? direction.normalized : direction;
    }

    public void ApplyGravity(float deltaTime)
    {
        var config = _config.VerticalMoveSettings;

        if (IsGrounded && _verticalVelocity <= 0f)
        {
            _verticalVelocity = config.GroundedStick;  
            return;
        }

        _verticalVelocity += config.Gravity * deltaTime;
        if (_verticalVelocity < config.TerminalVelocity)
            _verticalVelocity = config.TerminalVelocity;
    }


    public void MoveHorizontal(Vector3 desired, float accel, float decel, float deltaTime)
    {
        float rate = desired.sqrMagnitude > 0.01f ? accel : decel;
        _horizontalVelocity = Vector3.MoveTowards(_horizontalVelocity, desired, rate * deltaTime);
    }

    public void Move(float deltaTime)
    {
        Vector3 motion = _horizontalVelocity;
        motion.y = _verticalVelocity;

        CollisionFlags flags =_controller.Move(motion * deltaTime);

        IsGrounded = (flags & CollisionFlags.Below) != 0 || CheckGrounded();
    }

    public bool CheckGrounded()
    {
        Vector3 worldCenter = _controller.transform.TransformPoint(_controller.center);
        float halfHeight = Mathf.Max(_controller.height * 0.5f, _controller.radius);
        Vector3 bottomSphere = worldCenter - Vector3.up * (halfHeight - _controller.radius);

        Vector3 origin = bottomSphere + Vector3.up * 0.05f;
        float radius = _controller.radius * 0.9f;
        float distance = 0.15f + 0.05f;            

        return Physics.SphereCast(
            origin, radius, Vector3.down, out _,distance, _groundMask, QueryTriggerInteraction.Ignore);
    }
}
