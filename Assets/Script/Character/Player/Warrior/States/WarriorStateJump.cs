using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateJump", menuName = "Data/StateMachine/WarriorState/Jump")]
public class WarriorStateJump : WarriorState
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    float moveSpeed;

    public override void Enter()
    {
        base.Enter();

        warrior.SetVelocityY(jumpForce);
    }

    public override void LogicUpdate()
    {
        if (warrior.IsCeiling)
        {
            warrior.SetVelocityY(0);
        }

        if (warrior.YSpeed <= 0)
        {
            stateMachine.SwitchState(typeof(WarriorStateFall));
        }

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(WarriorStateAttack3));
        }
    }

    public override void PhysicUpdate()
    {
        warrior.SetFacing();

        if (input.Move)
        {
            warrior.SetVelocityX(input.Horizontal * moveSpeed);
        }
    }

    public override void Exit()
    {
    }
}
