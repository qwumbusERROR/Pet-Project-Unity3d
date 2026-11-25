using UnityEngine;
[CreateAssetMenu(fileName = "configInputSmooth", menuName = "Core/Input/Config/New Smooth Config")]
public sealed class InputSmoothConfig : ScriptableObject
{
    [Min(0)]public float DirectionRate = 10f;
}
