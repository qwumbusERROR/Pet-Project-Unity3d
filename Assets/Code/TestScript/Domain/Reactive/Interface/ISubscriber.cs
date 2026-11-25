namespace Domain.Reactive
{
    public interface ISubscriber<in TValue>
    {
        void OnValueChanged(TValue value);
    }
}