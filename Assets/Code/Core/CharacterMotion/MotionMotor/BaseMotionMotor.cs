using UnityEngine;
using VContainer.Unity;

public class BaseMotionMotor : ITickable
{
    private readonly CharacterController _controller;
    private readonly IMoveReadInput _moveInput;

    private Vector3 _velocity;
    private float _baseSpeed = 5f;

    public BaseMotionMotor(CharacterController controller, IMoveReadInput input)
    {
        _controller = controller;
        _moveInput = input;

        Debug.Log($"[Motor] создан. controller={controller != null}, input={input != null}");
    }

    public void Tick()
    {
        Vector2 move = _moveInput.ReadValue;

        ApplyBaseMove(move, Time.deltaTime);
    }

    private void ApplyBaseMove(Vector2 input, float time)
    {
        _velocity = _controller.transform.right * _moveInput.ReadValue.y + _controller.transform.forward * _moveInput.ReadValue.x;
        _controller.Move(_velocity * _baseSpeed * time);
    }
}
