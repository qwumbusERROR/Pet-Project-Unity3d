using System;
using Domain.Reactive;
using UnityEngine;

namespace Infrastructure.Reactive
{
    public abstract class ScriptableReactiveValue<TValue> : ScriptableObject, IReactiveValue<TValue>
    {
        [SerializeField] private bool _resetOnEnable = true;

        private ReactiveValue<TValue> _reactive;

        private ReactiveValue<TValue> Reactive
        {
            get
            {
                if (_reactive == null)
                    _reactive = new ReactiveValue<TValue>(GetInitialValue(), ex => Debug.LogException(ex, this));
                return _reactive;
            }
        }

        public TValue Value => Reactive.Value;

        protected abstract TValue GetInitialValue();

        private void OnEnable()
        {
            if (_reactive != null && _resetOnEnable)
                _reactive.ResetToInitial();
        }

        public void Subscribe(ISubscriber<TValue> subscriber) => Reactive.Subscribe(subscriber);
        public void Unsubscribe(ISubscriber<TValue> subscriber) => Reactive.Unsubscribe(subscriber);
        public void Set(TValue value) => Reactive.Set(value);
        public void ResetToInitial() => Reactive.ResetToInitial();
    }
}