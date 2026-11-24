using UnityEngine;
using Infrastructure.Input;
using Infrastructure.Config;

public class GameInput : MonoBehaviour
{
    private InputSystem_Actions _actions;
    [SerializeField] private InputSmoothConfigSO _inputSmoothConfig;

    public Vector2 MovePlayerInput {get; private set;}
    public Vector2 SmoothMovePlayerInput {get; private set;}

    public void OnEnable()
    {
        _actions = new InputSystem_Actions();
        _actions.Enable();
    }

    public void Update()
    {
        ReadMovePLayeInput();
    }

    private void ReadMovePLayeInput()
    {
        MovePlayerInput = _actions.Player.Move.ReadValue<Vector2>();
        SmoothMovePlayerInput = Damping.Exp(SmoothMovePlayerInput, MovePlayerInput, _inputSmoothConfig.DirectionRate, Time.deltaTime);
    }

    public void OnDisable()
    {
        _actions.Disable();

    }
}
