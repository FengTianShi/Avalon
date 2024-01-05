using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateBrake", menuName = "Data/StateMachine/PlayerState/Brake")]
public class PlayerStateBrake : PlayerState
{
    [SerializeField]
    float deceleration;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = Mathf.Abs(player.XSpeed);
    }

    public override void LogicUpdate()
    {
        if (currentSpeed == 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerStateRun));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerStateJump));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(PlayerStateAttack2));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        player.Decelerate(currentSpeed);
    }

    public override void Exit()
    {
    }
}
