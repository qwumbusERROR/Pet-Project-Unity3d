using UnityEngine.InputSystem;
using VContainer;

public class PlayerJumpProvider : IInputBoolProvider, System.IDisposable
{
    private readonly InputSystem_Actions _action;

    public ReactiveVariable<bool> InputCallback { get; private set; }

    public PlayerJumpProvider(InputSystem_Actions action, [Key("Jump")] ReactiveVariable<bool> jumpVariable)
    {
        _action = action;
        InputCallback = jumpVariable;

        _action.Player.Jump.performed += InputChanged;
        _action.Player.Jump.canceled  += InputChanged;
    }

    private void InputChanged(InputAction.CallbackContext context)
    {
        InputCallback.Value = !context.canceled;
    }

    public void Dispose()
    {
        _action.Player.Jump.performed -= InputChanged;
        _action.Player.Jump.canceled  -= InputChanged;
    }
}
