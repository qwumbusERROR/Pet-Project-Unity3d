using UnityEngine;
using VContainer;

public class InputDebugger : MonoBehaviour
{
    private IInputVectorProvider _move;
    private IInputVectorProvider _look;

    [Inject]
    public void Construct([Key("Move")] IInputVectorProvider move, [Key("Look")] IInputVectorProvider look)
    {
        _move = move;
        _look = look;
        Debug.Log($"[Debug] move={_move?.GetType().Name}, look={_look?.GetType().Name}");
    }

    private void Start()
    {
        if (_move != null) _move.InputValue.OnChange += v => Debug.Log($"[Move] {v}");
        if (_look != null) _look.InputValue.OnChange += v => Debug.Log($"[Look] {v}");
    }
}