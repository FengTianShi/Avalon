using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateRun", menuName = "Data/StateMachine/PlayerState/Run")]
public class PlayerStateRun : PlayerState
{
    [SerializeField]
    float runSpeed = 5;

    public override void Enter()
    {
        Debug.Log("Run State");

        animator.Play("Run");
    }

    public override void LogicUpdate()
    {
        // if (!Keyboard.current.aKey.isPressed && !Keyboard.current.dKey.isPressed)
        // {
        //     stateMachine.SwitchState(typeof(PlayerStateIdle));
        // }

        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        }
    }

    public override void PhysicUpdate()
    {
        controller.Move(runSpeed);
    }

    public override void Exit()
    {
    }
}
