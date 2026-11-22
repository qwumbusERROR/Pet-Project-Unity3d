using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{   
    public sealed class LookReader : ILookInput
    {
        private readonly InputSystem_Actions _actions;

        public LookReader(InputSystem_Actions actions)
        {
            _actions = actions;
        }

        public Vector2 ReadValue() => _actions.Player.Look.ReadValue<Vector2>(); 

    }
}

