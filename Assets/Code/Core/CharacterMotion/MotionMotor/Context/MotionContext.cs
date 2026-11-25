using UnityEngine;

public sealed class MotionContext 
{   
    public readonly IMoveReadInput MoveInput;
    public readonly IMotor Motor;
    public readonly CharacterMotionConfig MotionMotor;

    public Vector3 HorizontalVelocity;
}
