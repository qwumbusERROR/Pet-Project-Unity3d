using UnityEngine;

public class CharacterMotor
{
    private const float ShellRadiusMultiplier = 0.9f;
    private const float DirectionEpsilon = 0.01f;

    private readonly CharacterController _controller;
    private readonly MovementConfig.VerticalSettings _vertical;
    private readonly MovementConfig.GroundCheckSettings _groundCheck;
    private readonly LayerMask _groundMask;

    private readonly float _skin;
    private readonly float _shellRadius;

    private Vector3 _horizontalVelocity;
    private float _verticalVelocity;
    private bool _wasGrounded;

    public float VerticalVelocity => _verticalVelocity;
    public PlayerGroundedInfo Grounded { get; private set; }

    public CharacterMotor(CharacterController controller, MovementConfig config, LayerMask groundMask)
    {
        _controller = controller;
        _groundMask = groundMask;

        _vertical = config.VerticalMoveSettings;
        _groundCheck = config.GroundCheck;

        _skin = _controller.skinWidth;
        _shellRadius = _controller.radius * ShellRadiusMultiplier;
    }

    public Vector3 ToWorldDirection(Vector2 input)
    {
        Vector3 direction = _controller.transform.right * input.x + _controller.transform.forward * input.y;
        return direction.sqrMagnitude > 1f ? direction.normalized : direction;
    }

    public void ApplyGravity(float dt)
    {
        if (Grounded.StandingOnGround && _verticalVelocity <= 0f)
        {
            _verticalVelocity = _vertical.GroundedStick;
            return;
        }

        _verticalVelocity += _vertical.Gravity * dt;
        if (_verticalVelocity < _vertical.TerminalVelocity)
            _verticalVelocity = _vertical.TerminalVelocity;
    }

    public void MoveHorizontal(Vector3 desired, float accel, float decel, float dt)
    {
        float rate = desired.sqrMagnitude > DirectionEpsilon ? accel : decel;
        _horizontalVelocity = Vector3.MoveTowards(_horizontalVelocity, desired, rate * dt);
    }

    public void Move(float dt)
    {
        Vector3 motion = _horizontalVelocity;
        motion.y = _verticalVelocity;

        _controller.Move(motion * dt);
        SnapDown();

        Grounded = CheckGrounded();
        _wasGrounded = Grounded.StandingOnGround;
    }

    public void Jump()
        => _verticalVelocity = Mathf.Sqrt(2f * _vertical.JumpHeight * -_vertical.Gravity);

    private void SnapDown()
    {
        if (!_groundCheck.SnapDownEnabled || !_wasGrounded || _verticalVelocity > 0f)
            return;

        if (!TryCastDown(_groundCheck.SnapDownDistance + _skin, out RaycastHit hit))
            return;

        float snap = hit.distance - _skin;
        if (snap > 0f)
            _controller.Move(Vector3.down * snap);

        _verticalVelocity = 0f;
    }

    private PlayerGroundedInfo CheckGrounded()
    {
        float distance = _vertical.GroundedDistance + _skin;

        return TryCastDown(distance, out RaycastHit hit)
            ? new PlayerGroundedInfo(true, hit.distance - _skin, hit.normal, hit.collider.gameObject,
                _vertical.GroundedDistance, _vertical.MaxWalkAngle)
            : new PlayerGroundedInfo(false, float.PositiveInfinity, Vector3.up, null,
                _vertical.GroundedDistance, _vertical.MaxWalkAngle);
    }

    private bool TryCastDown(float distance, out RaycastHit hit)
    {
        Vector3 origin = GetCapsuleBottom() + Vector3.up * _skin;
        return Physics.SphereCast(origin, _shellRadius, Vector3.down, out hit,
            distance, _groundMask, QueryTriggerInteraction.Ignore);
    }

    private Vector3 GetCapsuleBottom()
    {
        Vector3 worldCenter = _controller.transform.TransformPoint(_controller.center);
        float halfHeight = Mathf.Max(_controller.height * 0.5f, _controller.radius);
        return worldCenter - Vector3.up * (halfHeight - _controller.radius);
    }
}
