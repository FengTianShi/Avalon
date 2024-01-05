using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateFall", menuName = "Data/StateMachine/PlayerState/Fall")]
public class PlayerStateFall : PlayerState
{
    [SerializeField]
    float moveSpeed;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
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
