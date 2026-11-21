using VContainer.Unity;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InputEntryPoint : IStartable, System.IDisposable
{
    private readonly InputActionService _service;
    private readonly List<IInputVectorProvider> _vectorProvider;
    private readonly List<IInputBoolProvider> _buttonProvider;

    public InputEntryPoint(InputActionService service, 
        IEnumerable<IInputVectorProvider> vectors, IEnumerable<IInputBoolProvider> buttons)
    {
        _service = service;
        _vectorProvider = vectors.ToList();
        _buttonProvider = buttons.ToList();
    }

    public void Start()
    {
        _service.EnableInput();

        #if UNITY_EDITOR
            Debug.Log("[InputEntryPoint] Input enabled");

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