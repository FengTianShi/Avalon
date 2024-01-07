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

        currentSpeed = enterSpeed;

        player.SetFacing();
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(PlayerStateDash));
        }

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
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
