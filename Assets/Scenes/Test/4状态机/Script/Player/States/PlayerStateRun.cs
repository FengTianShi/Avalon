using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateRun", menuName = "Data/StateMachine/PlayerState/Run")]
public class PlayerStateRun : PlayerState
{
    [SerializeField]
    float runSpeed;

    [SerializeField]
    float acceleration;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = Mathf.Abs(player.XSpeed);
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerStateBrake));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerStateJump));
        }

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(PlayerStateDash));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(PlayerStateAttack1));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.SetFacing();

        if (player.Slope != Vector2.zero)
        {
            player.SetVelocity(input.Horizontal * currentSpeed * -player.Slope);
        }
        else
        {
            if (player.YSpeed > 0)
            {
                player.SetVelocityY(0);
            }

            player.SetVelocityX(input.Horizontal * currentSpeed);
        }
    }

    public override void Exit()
    {
    }
}
