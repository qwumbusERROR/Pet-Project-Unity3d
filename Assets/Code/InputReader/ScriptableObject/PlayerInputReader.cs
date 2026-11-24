using UnityEngine;
using System;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputReader", menuName = "InputReader/New/PlayerInputReader")]
public class PlayerInputReader : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    public event Action<Vector2> MoveEvent;
    public event Action InteractEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }
}
