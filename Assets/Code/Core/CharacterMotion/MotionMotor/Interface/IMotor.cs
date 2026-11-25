using UnityEngine;

public interface IMotor 
{
    public Vector3 ReadVelocity {get;}
    public IMotionGroundInfo Grounded {get;}

    public void ApplyMover(Vector3 velocity, float time);
}
