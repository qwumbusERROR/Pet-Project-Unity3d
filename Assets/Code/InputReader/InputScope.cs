using UnityEngine;
using UnityEngine.InputSystem;

public class InputScope : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputRead;

    private InputSystem_Actions _action;

    private void OnEnable()
    {
        _action = new InputSystem_Actions();
        _action.Player.SetCallbacks(_playerInputRead);

        _action.Player.Enable();
    }

    private void OnDisable()
    {
        _action.Player.Disable();
    }

    /*
    public void SetPlayer()
    {
        _action.Player.Enable();
        _action.UI.Disable();
    }
    */
}
