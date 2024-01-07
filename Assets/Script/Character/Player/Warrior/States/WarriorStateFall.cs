using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateFall", menuName = "Data/StateMachine/WarriorState/Fall")]
public class WarriorStateFall : WarriorState
{
    [SerializeField]
    float moveSpeed;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(WarriorStateAttack3));
        }

        if (warrior.IsGrounded)
        {
            stateMachine.SwitchState(typeof(WarriorStateIdle));
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
