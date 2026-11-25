using System;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInputReader : InputSystem_Actions.IPlayerActions, IDisposable
{
    private readonly InputSystem_Actions _actions;

    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> LookEvent;

    public event Action InteractPressed;

    public PlayerInputReader(InputSystem_Actions actions)
    {
        _actions = actions;
        _actions.Player.SetCallbacks(this);
        
        Enable();
    }

    public void Enable()
    {
        _actions.Player.Enable();
    }

    public void Disable()
    {
        _actions.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
        => MoveEvent?.Invoke(context.ReadValue<Vector2>());

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            InteractPressed?.Invoke();
    }

    public void OnLook(InputAction.CallbackContext context)
        => LookEvent?.Invoke(context.ReadValue<Vector2>());

    public void OnAttack(InputAction.CallbackContext context)   { }
    public void OnCrouch(InputAction.CallbackContext context)   { }
    public void OnJump(InputAction.CallbackContext context)     { }
    public void OnNext(InputAction.CallbackContext context)     { }
    public void OnPrevious(InputAction.CallbackContext context) { }
    public void OnSprint(InputAction.CallbackContext context)   { }

    public void Dispose()
    {
        Disable();

        _actions.Player.RemoveCallbacks(this);
    }
}