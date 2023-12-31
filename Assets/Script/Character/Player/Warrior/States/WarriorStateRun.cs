using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateRun", menuName = "Data/StateMachine/WarriorState/Run")]
public class WarriorStateRun : WarriorState
{
    [SerializeField]
    float RunSpeed;

    [SerializeField]
    float Acceleration;

    public override void Enter()
    {
        base.Enter();

        CurrentSpeed = Mathf.Abs(Player.XSpeed);
    }

    public override void LogicUpdate()
    {
        CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, RunSpeed, Acceleration * Time.deltaTime);

        if (!Player.Input.IsMove)
        {
            StateMachine.SwitchState(typeof(WarriorStateBrake));
        }

        if (Player.Input.IsJump)
        {
            StateMachine.SwitchState(typeof(WarriorStateJump));
        }

        if (Player.Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Player.Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WarriorStateAttack1));
        }

        if (!Player.IsGrounded)
        {
            StateMachine.SwitchState(typeof(WarriorStateFall));
        }
    }

    public override void PhysicUpdate()
    {
        Player.SetFacing();

        Player.Move(CurrentSpeed);
    }

    public override void Exit()
    {
    }
}
