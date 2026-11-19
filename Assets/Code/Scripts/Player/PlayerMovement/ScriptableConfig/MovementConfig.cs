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

    public GroundMovementSettings GroundMoveSettings = new GroundMovementSettings();
}
