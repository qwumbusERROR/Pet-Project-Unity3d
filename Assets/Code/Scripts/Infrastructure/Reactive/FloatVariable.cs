using UnityEngine;

namespace Infrastructure.Reactive.Variables
{
    [CreateAssetMenu(menuName = "Reactive/New Variable/Float Variable", fileName = "FloatVariable")]
    public sealed class FloatVariable : ScriptableReactiveValue<float>
    {
        [SerializeField] private float _initialValue;
        protected override float GetInitialValue() => _initialValue;
    }
}