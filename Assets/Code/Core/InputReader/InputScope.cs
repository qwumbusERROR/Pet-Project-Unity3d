using UnityEngine;
using System; 
using VContainer;
using VContainer.Unity;

public sealed class InputScope : LifetimeScope
{
    [SerializeField] private InputSmoothConfig _smoothConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InputSystem_Actions>(Lifetime.Singleton);
        builder.RegisterInstance(_smoothConfig);

        builder.Register<PlayerInputReader>(Lifetime.Singleton)
                .AsSelf()
                .As<IDisposable>();

        builder.Register<PlayerMoveInputRead>(Lifetime.Singleton)
               .As<IMoveReadInput>()
               .As<IStartable>()
               .As<IDisposable>();

        builder.Register<PlayerLookInputRead>(Lifetime.Singleton)
               .As<ILookReadInput>()
               .As<IStartable>()
               .As<IDisposable>();
    }
}
