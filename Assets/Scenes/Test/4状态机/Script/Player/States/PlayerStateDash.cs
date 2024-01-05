using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateDash", menuName = "Data/StateMachine/PlayerState/Dash")]
public class PlayerStateDash : PlayerState
{
    [SerializeField]
    float dashSpeed;

    [SerializeField]
    float dashDuration;

    private float dashTime;

    private float dashDirection;

    public override void Enter()
    {
        base.Enter();

        dashTime = dashDuration;

        dashDirection = input.Horizontal;
        if (input.Horizontal == 0)
        {
            dashDirection = player.transform.localScale.x;
        }
    }

    public override void LogicUpdate()
    {
        dashTime -= Time.deltaTime;

        if (dashTime <= 0)
        {
            player.SetVelocityX(0);
            player.SetVelocityY(0);

            if (!player.IsGrounded)
            {
                stateMachine.SwitchState(typeof(PlayerStateFall));
            }

            stateMachine.SwitchState(typeof(PlayerStateBrake));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(PlayerStateAttack3));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocityX(dashDirection * dashSpeed);

        if (!player.IsGrounded)
        {
            player.SetVelocityY(0);
        }
    }

    public override void Exit()
    {
    }
}
