using UnityEngine;
using System;

public abstract class ReactiveVariable<T> : ScriptableObject
{
    [SerializeField] private T _initialValue;

    private T _value;

    public event Action<T> OnChange;

    public T Value
    {
        get => _value;
        set
        {
            if(Equals(_value,value)) return;

            _value = value;
            OnChange?.Invoke(_value);
        }
    }

    private void OnEnable() => _value = _initialValue;
}
