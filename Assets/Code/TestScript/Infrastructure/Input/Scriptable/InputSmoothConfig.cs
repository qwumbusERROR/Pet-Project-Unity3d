using UnityEngine;

namespace Infrastructure.Config
{
    [CreateAssetMenu(menuName = "Config/Input/Input Smoothing")]
    public sealed class InputSmoothingConfig : ScriptableObject
    {
        [Tooltip("Скорость сходимости направления")]
        [Range(1f, 40f)] public float DirectionRate = 12f;

        [Tooltip("Скорость сходимости магнитуды")]
        [Range(1f, 40f)] public float MagnitudeRate = 15f;

        [Tooltip("Кривая для плавного старта/стопа поверх магнитуды. X = время, Y = доля скорости")]
        public AnimationCurve StartStopCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Tooltip("Длительность прохождения StartStopCurve")]
        [Range(0.05f, 1f)] public float StartStopDuration = 0.2f;
    }
}