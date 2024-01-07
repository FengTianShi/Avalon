using UnityEngine;

[CreateAssetMenu(fileName = "WitcherStateRun", menuName = "Data/StateMachine/WitcherState/Run")]
public class WitcherStateRun : WitcherState
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
            StateMachine.SwitchState(typeof(WitcherStateIdle));
        }

        if (Player.Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WitcherStateAttack));
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
