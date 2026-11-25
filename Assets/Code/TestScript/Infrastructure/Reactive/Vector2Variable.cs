using UnityEngine;

namespace Infrastructure.Reactive.Variables
{
    [CreateAssetMenu(menuName = "Reactive/New Variable/Vector2 Variable", fileName = "Vector2Variable")]
    public sealed class Vector2Variable : ScriptableReactiveValue<Vector2>
    {
        [SerializeField] private Vector2 _initialValue;
        protected override Vector2 GetInitialValue() => _initialValue;
    }
}