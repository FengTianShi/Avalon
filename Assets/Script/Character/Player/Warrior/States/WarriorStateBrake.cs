using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateBrake", menuName = "Data/StateMachine/WarriorState/Brake")]
public class WarriorStateBrake : WarriorState
{
    [SerializeField]
    float deceleration;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = Mathf.Abs(warrior.XSpeed);
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (currentSpeed == 0)
        {
            stateMachine.SwitchState(typeof(WarriorStateIdle));
        }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(WarriorStateRun));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(WarriorStateJump));
        }

        if (input.Attack)
        {
            stateMachine.SwitchState(typeof(WarriorStateAttack3));
        }

        if (!warrior.IsGrounded)
        {
            stateMachine.SwitchState(typeof(WarriorStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        warrior.Move(currentSpeed);
    }

    public override void Exit()
    {
    }
}
