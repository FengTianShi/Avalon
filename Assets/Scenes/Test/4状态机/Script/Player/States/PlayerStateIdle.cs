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
