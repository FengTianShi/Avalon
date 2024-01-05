using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateAttack1", menuName = "Data/StateMachine/PlayerState/Attack1")]
public class PlayerStateAttack1 : PlayerState
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

        player.SetFacing();
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
        player.Decelerate(currentSpeed);
    }

    public override void Exit()
    {
    }
}
