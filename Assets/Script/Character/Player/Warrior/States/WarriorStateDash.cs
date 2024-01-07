using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateDash", menuName = "Data/StateMachine/WarriorState/Dash")]
public class WarriorStateDash : WarriorState
{
    [SerializeField]
    float dashSpeed;

    [SerializeField]
    float dashDuration;

    private float dashTime;

    public override void Enter()
    {
        base.Enter();

        warrior.SetFacing();

        dashTime = dashDuration;
    }

    public override void LogicUpdate()
    {
        dashTime -= Time.deltaTime;

        if (dashTime <= 0)
        {
            warrior.SetVelocityX(0);
            warrior.SetVelocityY(0);

            if (!warrior.IsGrounded)
            {
                stateMachine.SwitchState(typeof(WarriorStateFall));
            }
            else
            {
                stateMachine.SwitchState(typeof(WarriorStateBrake));
            }
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(WarriorStateAttack3));
        }
    }

    public override void PhysicUpdate()
    {
        warrior.SetVelocityX(warrior.transform.localScale.x * dashSpeed);

        if (!warrior.IsGrounded)
        {
            warrior.SetVelocityY(0);
        }
    }

    public override void Exit()
    {
    }
}
