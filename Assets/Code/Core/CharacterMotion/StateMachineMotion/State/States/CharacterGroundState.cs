using UnityEngine;

public class CharacterGroundState : IState
{
    private readonly MotionContext _context;

    public StateType Id => StateType.Grounded;

    public CharacterGroundState(MotionContext context)
    {
        _context = context;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public StateType Tickable(float time)
    {
        return Id;
    }
}
