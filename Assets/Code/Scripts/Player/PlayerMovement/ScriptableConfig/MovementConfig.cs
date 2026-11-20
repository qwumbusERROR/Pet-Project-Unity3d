using UnityEngine;

[CreateAssetMenu(fileName = "NewMoveConfig", menuName = "Player/MovementConfig/Create")]
public class MovementConfig : ScriptableObject
{
    [System.Serializable]public class GroundMovementSettings
    {
        [SerializeField, Range(1f, 50f), Tooltip("Скорость ходьбы")]
        private float _walkSpeed = 5f;
        public float WalkSpeed => _walkSpeed;

        [SerializeField, Range(1f, 2f), Tooltip("Множитель спринта к скорости ходьбы")]
        private float _sprintSpeedMultiplier = 1.2f;
        public float SprintSpeed => _walkSpeed * _sprintSpeedMultiplier;

        [SerializeField, Range(0.01f, 1f), Tooltip("Множитель скорости ходьбы назад")]
        private float _backwardSpeedMultiplier = 0.5f;
        public float BackwardSpeed => _walkSpeed * _backwardSpeedMultiplier;

        [SerializeField, Range(0.01f, 1f), Tooltip("Множитель скорости ходьбы по диагонали")]
        private float _strafeSpeedMultiplier = 0.75f;
        public float StrafeSpeed => _walkSpeed * _strafeSpeedMultiplier;

        [SerializeField, Range(0f, 20f), Tooltip("Ускорение ходьбы")]
        private float _acceleration = 1.5f;
        public float Acceleration => _acceleration;

        [SerializeField, Range(0f, 20f), Tooltip("Замедление ходьбы")]
        private float _deceleration = 1.5f;
        public float Deceleration => _deceleration;
    }
    [System.Serializable]public class VerticalSettings
    {
        [SerializeField, Range(-40f, -5f), Tooltip("Сила гравитации")]
        private float _gravity = -20f;
        public float Gravity => _gravity;

        [SerializeField, Range(-5f, 0f), Tooltip("Сила прижатия к земле")]
        private float _groundedStick = -2f;
        public float GroundedStick => _groundedStick;

         [SerializeField, Range(-60f, -10f), Tooltip("Предельная скорость падения")]
        private float _terminalVelocity = -40f;
        public float TerminalVelocity => _terminalVelocity;

        [SerializeField, Range(0f, 1f), Tooltip("Доля контроля в воздухе")]
        private float _airControlMultiplier = 0.3f;
        public float AirControlMultiplier => _airControlMultiplier;

        [SerializeField, Range(0.01f, 0.5f), Tooltip("Порог 'стою на земле'")]
        private float _groundedDistance = 0.15f;
        public float GroundedDistance => _groundedDistance;

        [SerializeField, Range(30f, 80f), Tooltip("Макс. угол проходимого склона")]
        private float _maxWalkAngle = 55f;
        public float MaxWalkAngle => _maxWalkAngle;
    }

    [System.Serializable]
    public class GroundCheckSettings
    {
        [SerializeField, Tooltip("Прижимать к земле при спуске по ступенькам/склонам")]
        private bool _snapDownEnabled = true;
        public bool SnapDownEnabled => _snapDownEnabled;

        [SerializeField, Range(0.05f, 1f), Tooltip("Макс. высота прижатия (≈ удвоенная высота ступеньки)")]
        private float _snapDownDistance = 0.4f;
        public float SnapDownDistance => _snapDownDistance;
    }

    public GroundMovementSettings GroundMoveSettings = new GroundMovementSettings();
    public VerticalSettings VerticalMoveSettings = new VerticalSettings();
    public GroundCheckSettings GroundCheck = new GroundCheckSettings();
}
