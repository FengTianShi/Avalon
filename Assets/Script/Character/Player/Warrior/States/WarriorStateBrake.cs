using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateBrake", menuName = "Data/StateMachine/WarriorState/Brake")]
public class WarriorStateBrake : WarriorState
{
    [SerializeField]
    float Deceleration;

    public override void Enter()
    {
        base.Enter();

        CurrentSpeed = Mathf.Abs(Player.XSpeed);
    }

    public override void LogicUpdate()
    {
        CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, 0, Deceleration * Time.deltaTime);

        if (CurrentSpeed == 0)
        {
            StateMachine.SwitchState(typeof(WarriorStateIdle));
        }

        if (Input.IsMove)
        {
            StateMachine.SwitchState(typeof(WarriorStateRun));
        }

        if (Input.IsJump)
        {
            StateMachine.SwitchState(typeof(WarriorStateJump));
        }

        if (Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WarriorStateAttack3));
        }

        if (!Player.IsGrounded)
        {
            StateMachine.SwitchState(typeof(WarriorStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        Player.Move(CurrentSpeed);
    }

    public override void Exit()
    {
    }
}
