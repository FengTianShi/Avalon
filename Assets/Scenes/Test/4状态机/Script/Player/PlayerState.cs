using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected PlayerStateMachine stateMachine;

    [SerializeField]
    string stateName;

    int stateHash;

    protected PlayerInput input;

    protected PlayerController player;

    protected Animator animator;

    [SerializeField, Range(0, 1)]
    protected float transitionDuration = 0.1f;

    protected float currentSpeed;

    void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public void Initialize(
        PlayerStateMachine stateMachine,
        PlayerInput input,
        PlayerController player,
        Animator animator
     )
    {
        this.stateMachine = stateMachine;
        this.input = input;
        this.player = player;
        this.animator = animator;
    }

    public virtual void Enter()
    {
        Debug.Log(stateName);

        animator.CrossFade(stateHash, transitionDuration);
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicUpdate()
    {
    }
}