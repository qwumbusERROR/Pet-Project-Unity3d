public interface IState
{
    public void Enter();
    public void Exit();
    public void Tick(float deltaTime);

    public System.Type GetNextState();
}
