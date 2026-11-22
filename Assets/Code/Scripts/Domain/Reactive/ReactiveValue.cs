using System;
using System.Collections.Generic;

namespace Domain.Reactive
{
    public class ReactiveValue<TValue> : IReactiveValue<TValue>
    {
        private readonly List<ISubscriber<TValue>> _subscribers = new List<ISubscriber<TValue>>();
        private readonly TValue _initialValue;
        private readonly Action<Exception> _onError;

        public TValue Value { get; private set; }

        public ReactiveValue(TValue initialValue, Action<Exception> onError = null)
        {
            _initialValue = initialValue;
            _onError = onError;
            Value = initialValue;
        }

        public void Subscribe(ISubscriber<TValue> subscriber)
        {
            if (subscriber == null || _subscribers.Contains(subscriber))
                return;

            _subscribers.Add(subscriber);
            subscriber.OnValueChanged(Value);
        }

        public void Unsubscribe(ISubscriber<TValue> subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Set(TValue value)
        {
            if (EqualityComparer<TValue>.Default.Equals(Value, value))
                return;

            Value = value;

            for (int i = _subscribers.Count - 1; i >= 0; i--)
            {
                try { _subscribers[i]?.OnValueChanged(value); }
                catch (Exception exc) { _onError?.Invoke(exc); }
            }
        }

        public void ResetToInitial() => Set(_initialValue);
    }
}