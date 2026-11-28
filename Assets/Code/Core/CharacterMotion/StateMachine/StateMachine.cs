using System;
using System.Collections.Generic;

public sealed class StateMachine
{
    private readonly Dictionary<Type, IState> _states = new();

    public IState Current{get; private set;}

    public event Action<IState> StateChanged;

    public StateMachine(IEnumerable<IState> states)
    {
        foreach (var state in states)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(states));

            _states.Add(state.GetType(), state);
        }
    }

    public void Initial(IState initState)
    {
        Current = initState ?? throw new ArgumentNullException(nameof(initState));
        initState.Enter();
    }

    public T Get<T>() where T : class, IState => (T)_states[typeof(T)];

    public void Tick(float deltaTime)
    {
        Current.Tick(deltaTime);

        var nextType = Current.GetNextState();
        if (nextType != null && nextType != Current.GetType())
            ChangeState(nextType);
    }

    private void ChangeState(Type nextState)
    {
        if(nextState is null)
        {
            return;
        }

        if(!_states.TryGetValue(nextState, out var next))
        {
            return;
        }

        if(next == Current)
        {
            return;
        }

        Current.Exit();
        Current = next;
        Current.Enter();
        StateChanged?.Invoke(Current);
    }
}
