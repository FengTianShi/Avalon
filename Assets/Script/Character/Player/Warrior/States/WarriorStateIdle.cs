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
        if (Player.Input.IsMove)
        {
            StateMachine.SwitchState(typeof(WarriorStateRun));
        }

        if (Player.Input.IsJump)
        {
            StateMachine.SwitchState(typeof(WarriorStateJump));
        }

        if (Player.Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Player.Input.IsAttack)
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
        Player.Stop();
    }

    public override void Exit()
    {
    }
}
