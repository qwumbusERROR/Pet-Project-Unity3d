public interface IState
{
    public StateType Id{get;}

    public void Enter();
    public StateType Tickable(float time);

    public void Exit();
}
