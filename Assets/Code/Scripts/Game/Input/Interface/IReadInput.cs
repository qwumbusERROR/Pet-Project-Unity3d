namespace Game.Input
{
    public interface IReadInput<TValue>
    {
        public TValue ReadValue();
    }
}

