using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateDash", menuName = "Data/StateMachine/WarriorState/Dash")]
public class WarriorStateDash : WarriorState
{
    [SerializeField]
    float DashSpeed;

    [SerializeField]
    float DashDuration;

    private float DashTime;

    public override void Enter()
    {
        base.Enter();

        Player.SetFacing();

        DashTime = DashDuration;
    }

    public override void LogicUpdate()
    {
        DashTime -= Time.deltaTime;

        if (DashTime <= 0)
        {
            Player.Stop();

            if (!Player.IsGrounded)
            {
                StateMachine.SwitchState(typeof(WarriorStateFall));
            }
            else
            {
                StateMachine.SwitchState(typeof(WarriorStateBrake));
            }
        }

        if (Player.Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WarriorStateAttack3));
        }
    }

    public override void PhysicUpdate()
    {
        Player.SetVelocityX(Player.transform.localScale.x * DashSpeed);

        if (!Player.IsGrounded)
        {
            Player.SetVelocityY(0);
        }
    }

    public override void Exit()
    {
    }
}
