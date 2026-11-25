using UnityEngine;
[CreateAssetMenu(fileName = "characterMotionConfig", menuName = "Core/Character/Config/New CharacterMotion Config")]
public class CharacterMotionConfig : ScriptableObject
{
    [System.Serializable]
    public class HorizontalMovement
    {
        [SerializeField, Range(1f, 50f)]
        private float _walkSpeed = 5f;
        public float WalkSpeed => _walkSpeed;

        [SerializeField, Range(1f, 3f)]
        private float _sprintSpeedMultiplier = 1.2f;
        public float SprintSpeed => _walkSpeed * _sprintSpeedMultiplier;
    }

    public HorizontalMovement HorizontalMoveConfig = new HorizontalMovement();
}
