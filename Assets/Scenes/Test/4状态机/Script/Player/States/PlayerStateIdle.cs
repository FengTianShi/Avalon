using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateIdle", menuName = "Data/StateMachine/PlayerState/Idle")]
public class PlayerStateIdle : PlayerState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerStateRun));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerStateJump));
        }

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(PlayerStateDash));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(PlayerStateAttack1));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityX(0);
        player.SetVelocityY(0);
    }

    public override void Exit()
    {
    }
}
