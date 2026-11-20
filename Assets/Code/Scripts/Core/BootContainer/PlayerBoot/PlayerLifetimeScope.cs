using VContainer;
using VContainer.Unity;
using UnityEngine;

public class PlayerLifetimeScope : LifetimeScope
{
    [SerializeField] private MovementConfig _playerMoveConfig;
    [SerializeField] private CharacterController _playerController;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_playerController);
        builder.RegisterInstance(_playerMoveConfig);

        builder.Register<CharacterMotor>(Lifetime.Singleton);

        builder.Register<GroundedState>(Lifetime.Singleton).As<IMovementState>();

        builder.Register<MovementStateMachine>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerMovement>();
    }
}
