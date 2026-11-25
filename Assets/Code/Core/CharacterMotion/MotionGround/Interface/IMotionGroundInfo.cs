using UnityEngine;

public interface IMotionGroundInfo
{
    public bool OnGrounded { get; }
    public float DistanceToGrounded { get; }
    public Vector3 SurfaceNormal { get; }
    public float Angle { get; }
    public GameObject Floor { get; }
}
