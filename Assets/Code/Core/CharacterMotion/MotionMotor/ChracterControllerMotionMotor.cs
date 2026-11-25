using UnityEngine;

public sealed class ChracterControllerMotionMotor : IMotor
{
    private readonly CharacterController _controller;
    public CharacterController Controller => _controller;

    public Vector3 ReadVelocity {get; private set;}
    public IMotionGroundInfo Grounded {get;}

    public void ApplyMover(Vector3 velocity, float time)
    {
        Vector3 delta = velocity * time;

        _controller.Move(delta);

        ReadVelocity = _controller.velocity;
    }
}
