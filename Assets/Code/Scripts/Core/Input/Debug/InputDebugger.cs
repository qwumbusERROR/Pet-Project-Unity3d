using UnityEngine;
using VContainer;

public class InputDebugger : MonoBehaviour
{
    private IInputVectorProvider _move;
    private IInputVectorProvider _look;

    [Inject]
    public void Construct(IObjectResolver resolver)
    {
        _move = resolver.Resolve<IInputVectorProvider>("Move");
        _look = resolver.Resolve<IInputVectorProvider>("Look");
        Debug.Log($"[Debug] move={_move?.GetType().Name}, look={_look?.GetType().Name}");
    }

    private void Start()
    {
        if (_move != null) _move.InputValue.OnChange += v => Debug.Log($"[Move] {v}");
        if (_look != null) _look.InputValue.OnChange += v => Debug.Log($"[Look] {v}");
    }
}