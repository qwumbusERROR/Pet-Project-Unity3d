using UnityEngine;

public readonly struct PlayerGroundedInfo
{
    public bool OnGrounded { get; }
    public float DistanceToGrounded { get; }
    public Vector3 SurfaceNormal { get; }
    public float Angle { get; }
    public GameObject Floor { get; }

    public bool StandingOnGround { get; }
    public bool Falling => !StandingOnGround;
    public bool Sliding { get; }

    public PlayerGroundedInfo(bool onGround, float distance, Vector3 normal,GameObject floor, float groundedDistance, float maxWalkAngle)
    {
        OnGrounded = onGround;
        DistanceToGrounded = distance;
        SurfaceNormal = normal;
        Angle = Vector3.Angle(normal, Vector3.up);
        Floor = floor;

        StandingOnGround = onGround && distance >= 0f && distance <= groundedDistance;
        Sliding = StandingOnGround && Angle > maxWalkAngle;
    }
}
