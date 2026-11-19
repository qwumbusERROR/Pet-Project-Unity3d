using UnityEngine.InputSystem;

public class InputActionService
{
    private readonly InputSystem_Actions _actions;

    public InputActionService(InputSystem_Actions actions)
    {
        _actions = actions;
    }

    public void EnableInput()  => _actions.Player.Enable();
    public void DisableInput() => _actions.Player.Disable();
}