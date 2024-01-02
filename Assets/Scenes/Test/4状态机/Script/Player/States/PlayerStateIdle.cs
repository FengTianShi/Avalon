using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateIdle", menuName = "Data/StateMachine/PlayerState/Idle")]
public class PlayerStateIdle : PlayerState
{
    public override void Enter()
    {
        Debug.Log("Idle State");

        animator.Play("Idle");
        controller.SetVelocity(Vector2.zero);
    }

    public override void LogicUpdate()
    {
        // if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
        // {
        //     stateMachine.SwitchState(typeof(PlayerStateRun));
        // }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerStateRun));
        }
    }

    public override void PhysicUpdate()
    {
    }

    public override void Exit()
    {
    }
}
