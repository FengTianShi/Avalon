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
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

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
            stateMachine.SwitchState(typeof(PlayerStateAttack3));
        }

        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
    }

    public override void Exit()
    {
    }
}
