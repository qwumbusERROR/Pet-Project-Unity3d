using UnityEngine;
using System; 
using VContainer;
using VContainer.Unity;

public class CharacterScope : LifetimeScope
{
    [SerializeField] private CharacterController _controller;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_controller);
        builder.RegisterEntryPoint<BaseMotionMotor>();
    }
}
