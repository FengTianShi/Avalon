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
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);

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
        player.SetFacing();

        player.Move(currentSpeed);
    }

    public override void Exit()
    {
    }
}
