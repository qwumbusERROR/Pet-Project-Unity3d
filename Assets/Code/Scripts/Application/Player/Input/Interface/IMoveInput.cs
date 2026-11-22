using UnityEngine;

namespace Application.Input
{
    public interface IMoveInput : IReadInput<Vector2>
    {
        public Vector2 ReadValue();
    }
}

