using UnityEngine;

public interface IMovementState 
{
    public MovementStateId Id {get;}

    public void Enter();
    public MovementStateId Tick(Vector2 input, float deltaTime);
    public void Exit();
}
