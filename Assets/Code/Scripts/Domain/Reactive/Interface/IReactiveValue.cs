namespace Domain.Reactive
{
    public interface IReactiveValue<TValue>
    {
        public TValue Value { get; }
        public void Subscribe(ISubscriber<TValue> subscriber);
        public void Unsubscribe(ISubscriber<TValue> subscriber);
        public void Set(TValue value);
    }
}