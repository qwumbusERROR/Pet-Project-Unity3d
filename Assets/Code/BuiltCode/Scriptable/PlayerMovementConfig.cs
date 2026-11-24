using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "BuiltCode/Config/Player/Movement")]
public class PlayerMovementConfig : ScriptableObject
{
    [System.Serializable]
    public class HorizontalMovement
    {
        public float MoveSpeed = 3f;
    }

    public HorizontalMovement HorizontalMove = new HorizontalMovement();
}
