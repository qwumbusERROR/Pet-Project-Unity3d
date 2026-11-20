using UnityEngine;

public class CharacterMotor
{
    private readonly CharacterController _controller;
    private readonly MovementConfig _config;
    private readonly LayerMask _groundMask;

    private Vector3 _horizontalVelocity;
    private float _verticalVelocity;

    public float VerticalVelocity => _verticalVelocity;
    public PlayerGroundedInfo Grounded {get; private set;}

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

        if (Grounded.StandingOnGround && _verticalVelocity <= 0f)
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

        _controller.Move(motion * deltaTime);

        Grounded = CheckGrounded();
    }

    private PlayerGroundedInfo CheckGrounded()
    {
        var verticalSettings = _config.VerticalMoveSettings;

        Vector3 worldCenter = _controller.transform.TransformPoint(_controller.center);
        float halfHeight = Mathf.Max(_controller.height * 0.5f, _controller.radius);
        Vector3 bottom = worldCenter - Vector3.up * (halfHeight - _controller.radius);

        float radius = _controller.radius * 0.9f;
        float skin = _config.GroundCheck.SkinWidth;
        float distance = verticalSettings.GroundedDistance + skin;

        Vector3 origin = bottom + Vector3.up * skin;

        if (Physics.SphereCast(origin, radius, Vector3.down, out RaycastHit hit,
                distance, _groundMask, QueryTriggerInteraction.Ignore))
        {
            return new PlayerGroundedInfo(
                onGround: true,
                distance: hit.distance - skin,
                normal: hit.normal,
                floor: hit.collider.gameObject,
                groundedDistance: verticalSettings.GroundedDistance,
                maxWalkAngle: verticalSettings.MaxWalkAngle);
        }

        return new PlayerGroundedInfo(
            onGround: false,
            distance: float.PositiveInfinity,
            normal: Vector3.up,
            floor: null,
            groundedDistance: verticalSettings.GroundedDistance,
            maxWalkAngle: verticalSettings.MaxWalkAngle);
    }
}
