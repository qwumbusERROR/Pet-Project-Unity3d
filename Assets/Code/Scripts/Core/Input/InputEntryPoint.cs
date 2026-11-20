using VContainer.Unity;
using UnityEngine;
using System.Collections.Generic;

public class InputEntryPoint : IStartable, System.IDisposable
{
    private readonly InputActionService _service;
    private readonly IEnumerable<IInputVectorProvider> _providers;

    public InputEntryPoint(InputActionService service, IEnumerable<IInputVectorProvider> providers)
    {
        _service = service;
        _providers = providers;
    }

    public void Start()
    {
        _service.EnableInput();

        #if UNITY_EDITOR
            Debug.Log("[InputEntryPoint] Input enabled");
            Debug.Log($"[InputEntryPoint] providers={System.Linq.Enumerable.Count(_providers)}");

        #endif
    }

    public void Dispose()
    {
        _service.DisableInput();

        #if UNITY_EDITOR
            Debug.Log("[InputEntryPoint] Input disabled");

        #endif
    }
}