using UnityEngine;

[CreateAssetMenu(fileName = "WitcherStateIdle", menuName = "Data/StateMachine/WitcherState/Idle")]
public class WitcherStateIdle : WitcherState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (Player.Input.IsMove)
        {
            StateMachine.SwitchState(typeof(WitcherStateRun));
        }

        if (Player.Input.IsAttack)
        {
            StateMachine.SwitchState(typeof(WitcherStateAttack));
        }
    }

    public override void PhysicUpdate()
    {
        Player.Stop();
    }

    public override void Exit()
    {
    }
}
