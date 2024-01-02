using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected PlayerInput input;

    protected PlayerController controller;

    protected Animator animator;

    protected PlayerStateMachine stateMachine;

    public void Initialize(
        PlayerInput input,
        PlayerController controller,
        Animator animator,
        PlayerStateMachine stateMachine)
    {
        this.input = input;
        this.controller = controller;
        this.animator = animator;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Exit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void LogicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public virtual void PhysicUpdate()
    {
        throw new System.NotImplementedException();
    }
}