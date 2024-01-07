using UnityEngine;

public class CharacterState : ScriptableObject, IState
{
    protected CharacterStateMachine StateMachine;

    [SerializeField]
    protected string StateName;

    protected int StateHash;

    protected CharacterController Character;

    protected Animator Animator;

    [SerializeField, Range(0, 1)]
    protected float TransitionDuration = 0.1f;

    protected float StateStartTime;

    protected float AnimationDuration => Animator.GetCurrentAnimatorStateInfo(0).length;

    protected float CurrentStateDuration => Time.time - StateStartTime;

    protected bool IsAnimationFinished => CurrentStateDuration >= AnimationDuration;

    void OnEnable()
    {
        StateHash = Animator.StringToHash(StateName);
    }

    public void Initialize(
        CharacterStateMachine stateMachine,
        CharacterController character,
        Animator animator)
    {
        StateMachine = stateMachine;
        Character = character;
        Animator = animator;
    }

    public virtual void Enter()
    {
        Debug.Log(StateName);

        StateStartTime = Time.time;

        Animator.CrossFade(StateHash, TransitionDuration);
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
