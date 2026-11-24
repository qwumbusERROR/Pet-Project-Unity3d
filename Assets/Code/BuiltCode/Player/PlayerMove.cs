using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerContext _context;

    public Grounded Grounded { get; private set; }

    private Vector3 _horizontalVelocity;

    public void Update()
    {
        _horizontalVelocity = ConverterInputDirection(_context.InputGame.SmoothMovePlayerInput);
        _context.ControllerPlayer.Move(_horizontalVelocity * 3f * Time.deltaTime);
    }

    private Vector3 ConverterInputDirection(Vector2 input)
    {
        return _context.ControllerPlayer.transform.right * input.x + _context.ControllerPlayer.transform.forward * input.y;
    }
}
