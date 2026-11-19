using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class PlayerMoveProvider : IInputVectorProvider, System.IDisposable
{
    private InputSystem_Actions _action;

    public ReactiveVariable<Vector2> InputValue { get; private set; }

    public PlayerMoveProvider(InputSystem_Actions action, [Key("Move")] ReactiveVariable<Vector2> moveVector)
    {
        _action = action;
        InputValue = moveVector;

        _action.Player.Move.performed += InputChanged;
        _action.Player.Move.canceled  += InputChanged;
    }

    private void InputChanged(InputAction.CallbackContext context)
    {
        InputValue.Value = context.canceled ? Vector2.zero : context.ReadValue<Vector2>();
    }

    public void Dispose()
    {
        _action.Player.Move.performed -= InputChanged;
        _action.Player.Move.canceled  -= InputChanged;
    }
}