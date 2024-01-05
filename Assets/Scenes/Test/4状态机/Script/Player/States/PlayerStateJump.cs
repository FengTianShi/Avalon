using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateJump", menuName = "Data/StateMachine/PlayerState/Jump")]
public class PlayerStateJump : PlayerState
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    float moveSpeed;

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(jumpForce);
    }

    public override void LogicUpdate()
    {
        if (player.IsCeiling)
        {
            player.SetVelocityY(0);
        }

        if (player.YSpeed <= 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(PlayerStateDash));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(PlayerStateAttack3));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetFacing();

        if (input.Move)
        {
            player.SetVelocityX(input.Horizontal * moveSpeed);
        }
    }

    public override void Exit()
    {
    }
}
