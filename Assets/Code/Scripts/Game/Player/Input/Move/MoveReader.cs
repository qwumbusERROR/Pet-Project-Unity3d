using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{   
    public sealed class MoveReader : IMoveInput
    {
        private readonly InputSystem_Actions _actions;

        public MoveReader(InputSystem_Actions actions)
        {
            _actions = actions;
        }

        public Vector2 ReadValue() => _actions.Player.Move.ReadValue<Vector2>(); 

    }
}

