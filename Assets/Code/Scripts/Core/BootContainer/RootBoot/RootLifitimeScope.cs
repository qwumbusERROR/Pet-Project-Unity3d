using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class RootLifitimeScope : LifetimeScope
{
    [Header("Input global services")]
    [SerializeField] private ReactiveVariable<Vector2> _moveVector;
    [SerializeField] private ReactiveVariable<Vector2> _lookVector;

    protected override void Configure(IContainerBuilder builder)
    {
         builder.RegisterInstance(_moveVector)
               .Keyed("Move")
               .As<ReactiveVariable<Vector2>>();

        builder.RegisterInstance(_lookVector)
               .Keyed("Look")
               .As<ReactiveVariable<Vector2>>();

        builder.Register<InputSystem_Actions>(Lifetime.Singleton);

        builder.Register<InputActionService>(Lifetime.Singleton);

        builder.Register<PlayerMoveProvider>(Lifetime.Singleton)
               .As<IInputVectorProvider>()
               .As<System.IDisposable>();

        builder.Register<CameraLookProvider>(Lifetime.Singleton)
               .As<IInputVectorProvider>()
               .As<System.IDisposable>();

        builder.RegisterEntryPoint<InputEntryPoint>();
    }
}