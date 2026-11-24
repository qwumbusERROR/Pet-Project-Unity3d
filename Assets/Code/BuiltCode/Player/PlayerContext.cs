using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    public CharacterController ControllerPlayer => _controller;

    [SerializeField] private PlayerMovementConfig _configMove;
    public PlayerMovementConfig ConfigMove => _configMove;

    [SerializeField] private GameInput _gameInput;
    public GameInput InputGame => _gameInput;
}
