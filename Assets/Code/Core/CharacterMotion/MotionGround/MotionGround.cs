using UnityEngine;

public readonly struct MotionGround : IMotionGroundInfo
{
    public bool OnGrounded { get; }
    public float DistanceToGrounded { get; }
    public Vector3 SurfaceNormal { get; }
    public float Angle { get; }
    public GameObject Floor { get; }

    public MotionGround(bool onGround, float distance, Vector3 normal,GameObject floor)
    {
        OnGrounded = onGround;
        DistanceToGrounded = distance;
        SurfaceNormal = normal;
        Angle = Vector3.Angle(normal, Vector3.up);
        Floor = floor;
    }
}
