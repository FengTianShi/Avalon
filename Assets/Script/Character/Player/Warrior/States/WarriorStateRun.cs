using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateRun", menuName = "Data/StateMachine/WarriorState/Run")]
public class WarriorStateRun : WarriorState
{
    [SerializeField]
    float runSpeed;

    [SerializeField]
    float acceleration;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = Mathf.Abs(warrior.XSpeed);
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);

        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(WarriorStateBrake));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(WarriorStateJump));
        }

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(WarriorStateAttack1));
        }

        if (!warrior.IsGrounded)
        {
            stateMachine.SwitchState(typeof(WarriorStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        warrior.SetFacing();

        warrior.Move(currentSpeed);
    }

    public override void Exit()
    {
    }
}
