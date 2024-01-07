using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateFall", menuName = "Data/StateMachine/WarriorState/Fall")]
public class WarriorStateFall : WarriorState
{
    [SerializeField]
    float MoveSpeed;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (Player.Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Player.Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WarriorStateAttack3));
        }

        if (Player.IsGrounded)
        {
            StateMachine.SwitchState(typeof(WarriorStateIdle));
        }
    }

    public override void PhysicUpdate()
    {
        Player.SetFacing();

        if (Player.Input.IsMove)
        {
            Player.SetVelocityX(Player.Input.XInput * MoveSpeed);
        }
    }

    public override void Exit()
    {
    }
}
