namespace Application.Input
{
    public interface IReadInput<TValue>
    {
        public TValue ReadValue();
    }
}

