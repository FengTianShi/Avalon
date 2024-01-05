using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateAttack3", menuName = "Data/StateMachine/PlayerState/Attack3")]
public class PlayerStateAttack3 : PlayerState
{
    [SerializeField]
    float enterSpeed;

    [SerializeField]
    float deceleration;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = Mathf.Abs(enterSpeed);

        player.SetFacing();
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
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
