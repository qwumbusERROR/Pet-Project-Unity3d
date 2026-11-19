using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class CameraLookProvider : IInputVectorProvider, System.IDisposable
{
    private InputSystem_Actions _action;

    public ReactiveVariable<Vector2> InputValue { get; private set; }

    public CameraLookProvider(InputSystem_Actions action, [Key("Look")] ReactiveVariable<Vector2> lookVector)
    {
        _action = action;
        InputValue = lookVector;

        _action.Player.Look.performed += InputChanged;
        _action.Player.Look.canceled  += InputChanged;
    }

    private void InputChanged(InputAction.CallbackContext context)
    {
        InputValue.Value = context.canceled ? Vector2.zero : context.ReadValue<Vector2>();
    }

    public void Dispose()
    {
        _action.Player.Look.performed -= InputChanged;
        _action.Player.Look.canceled  -= InputChanged;
    }
}