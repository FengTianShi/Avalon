using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateAttack1", menuName = "Data/StateMachine/PlayerState/Attack1")]
public class PlayerStateAttack1 : PlayerState
{
    [SerializeField]
    float enterSpeed;

    [SerializeField]
    float deceleration;

    private bool isContinueAttack;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = enterSpeed;

        isContinueAttack = false;
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(PlayerStateDash));
        }

        if (input.Attack)
        {
            isContinueAttack = true;
        }

        if (IsAnimationFinished)
        {
            if (isContinueAttack)
            {
                stateMachine.SwitchState(typeof(PlayerStateAttack2));
            }
            else
            {
                stateMachine.SwitchState(typeof(PlayerStateIdle));
            }
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
