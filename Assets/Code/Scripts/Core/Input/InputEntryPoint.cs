using VContainer.Unity;
using UnityEngine;

public class InputEntryPoint : IStartable, System.IDisposable
{
    private readonly InputActionService _service;

    public InputEntryPoint(InputActionService service) => _service = service;

    public void Start()
    {
        _service.EnableInput();
        Debug.Log("[InputEntryPoint] Input enabled");
    }

    public void Dispose()
    {
        _service.DisableInput();
        Debug.Log("[InputEntryPoint] Input disabled");
    }
}