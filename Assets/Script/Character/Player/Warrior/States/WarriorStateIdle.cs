using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateIdle", menuName = "Data/StateMachine/WarriorState/Idle")]
public class WarriorStateIdle : WarriorState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(WarriorStateRun));
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
        warrior.SetVelocityX(0);
        warrior.SetVelocityY(0);
    }

    public override void Exit()
    {
    }
}
