using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateAttack2", menuName = "Data/StateMachine/PlayerState/Attack2")]
public class PlayerStateAttack2 : PlayerState
{
    [SerializeField]
    float enterSpeed;

    [SerializeField]
    float deceleration;

    private bool isAttack;

    public override void Enter()
    {
        base.Enter();

        isAttack = false;
        currentSpeed = Mathf.Abs(enterSpeed);
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (input.Attack)
        {
            isAttack = true;
        }

        if (IsAnimationFinished)
        {
            if (isAttack)
            {
                stateMachine.SwitchState(typeof(PlayerStateAttack3));
            }
            else
            {
                stateMachine.SwitchState(typeof(PlayerStateIdle));
            }
        }
    }

    public override void PhysicUpdate()
    {
        player.Decelerate(currentSpeed);
    }

    public override void Exit()
    {
    }
}
