using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateJump", menuName = "Data/StateMachine/WarriorState/Jump")]
public class WarriorStateJump : WarriorState
{
    [SerializeField]
    float JumpForce;

    [SerializeField]
    float MoveSpeed;

    public override void Enter()
    {
        base.Enter();

        Player.SetVelocityY(JumpForce);
    }

    public override void LogicUpdate()
    {
        if (Player.IsCeiling)
        {
            Player.SetVelocityY(0);
        }

        if (Player.YSpeed <= 0)
        {
            StateMachine.SwitchState(typeof(WarriorStateFall));
        }

        if (Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WarriorStateAttack3));
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
