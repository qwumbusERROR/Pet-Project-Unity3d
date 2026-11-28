using UnityEngine;
[CreateAssetMenu(fileName = "motionConfig", menuName = "Core/Motion/Config/New Motion Config")]
public sealed class MotionConfig : ScriptableObject, IMotionConfig
{
    [SerializeField] private HorizontalMove _horizontalSettings = new();
    public IHorizintalConfig Horizontal => _horizontalSettings; 

    [SerializeField] private VerticalMove _verticalSettings = new();
    public IVerticalConfig Vertical => _verticalSettings;

    [System.Serializable]
    public class HorizontalMove : IHorizintalConfig
    {
        [field: SerializeField, Min(0f)] public float WalkSpeed { get; private set; } = 6f;
    }

    [System.Serializable]
    public class VerticalMove : IVerticalConfig
    {
        [field: SerializeField, Range(-40f, 0f)] public float GravityScale { get; private set; } = -10f;
    }
    
}
