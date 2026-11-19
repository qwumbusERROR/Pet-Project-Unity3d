using UnityEngine;

public class CharacterMotor
{
    private readonly CharacterController _controller;
    private readonly MovementConfig _config;

    private Vector3 _horizontalVelocity;
    private float _verticalVelocity;

    public float VerticalVelocity => _verticalVelocity;

    public bool IsGrounded => Physics.Raycast(_controller.transform.position, Vector3.down,
    _controller.height * 0.5f + 0.15f);

    public CharacterMotor(CharacterController controller, MovementConfig config)
    {
        _controller = controller;
        _config = config;
    }

    public Vector3 ToWorldDirection(Vector2 input)
    {
        Vector3 direction = _controller.transform.right * input.x + _controller.transform.forward * input.y;
        return direction.sqrMagnitude > 1f ? direction.normalized : direction;
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
    }
}
