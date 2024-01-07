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
        if (Input.IsMove)
        {
            StateMachine.SwitchState(typeof(WarriorStateRun));
        }

        if (Input.IsJump)
        {
            StateMachine.SwitchState(typeof(WarriorStateJump));
        }

        if (Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WarriorStateAttack1));
        }

        if (!Player.IsGrounded)
        {
            StateMachine.SwitchState(typeof(WarriorStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        Player.SetVelocityX(0);
        Player.SetVelocityY(0);
    }

    public override void Exit()
    {
    }
}
