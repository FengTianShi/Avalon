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
        if (Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Input.IsAttack)
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

        if (Input.IsMove)
        {
            Player.SetVelocityX(Input.XInput * MoveSpeed);
        }
    }

    public override void Exit()
    {
    }
}
