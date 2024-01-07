using System.Linq;

public class PlayerStateMachine : CharacterStateMachine
{
    protected PlayerInput Input;

    protected override void Awake()
    {
        Input = GetComponent<PlayerInput>();

        base.Awake();
    }

    protected override void InitializeStates()
    {
        foreach (PlayerState state in States.Cast<PlayerState>())
        {
            state.Initialize(this, (PlayerController)Character, Animator, Input);
            StateTable.Add(state.GetType(), state);
        }
    }
}
