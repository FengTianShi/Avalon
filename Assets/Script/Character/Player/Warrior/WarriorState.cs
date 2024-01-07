using UnityEngine;

public class WarriorState : ScriptableObject, IState
{
    protected WarriorStateMachine stateMachine;

    [SerializeField]
    string stateName;

    int stateHash;

    protected WarriorInput input;

    protected WarriorController warrior;

    protected Animator animator;

    [SerializeField, Range(0, 1)]
    protected float transitionDuration = 0.1f;

    protected float currentSpeed;

    private float stateStartTime;

    protected float AnimationDuration => animator.GetCurrentAnimatorStateInfo(0).length;

    protected float CurrentStateDuration => Time.time - stateStartTime;

    protected bool IsAnimationFinished => CurrentStateDuration >= AnimationDuration;

    void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public void Initialize(
        WarriorStateMachine stateMachine,
        WarriorInput input,
        WarriorController warrior,
        Animator animator
     )
    {
        this.stateMachine = stateMachine;
        this.input = input;
        this.warrior = warrior;
        this.animator = animator;
    }

    public virtual void Enter()
    {
        Debug.Log(stateName);

        stateStartTime = Time.time;

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
