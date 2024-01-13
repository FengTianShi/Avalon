using UnityEngine;

[CreateAssetMenu(fileName = "UndeadStateIdle", menuName = "Data/StateMachine/UndeadState/Idle")]
public class UndeadStateIdle : UndeadState
{
    [SerializeField]
    float IdleTime;

    float Timer;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        Timer += Time.deltaTime;

        if (Timer >= IdleTime)
        {
            StateMachine.SwitchState(typeof(UndeadStatePatrol));
        }

        if (Enemy.Target != null)
        {
            StateMachine.SwitchState(typeof(UndeadStateReact));
        }
    }

    public override void PhysicUpdate()
    {
        Enemy.Stop();
    }

    public override void Exit()
    {
        Timer = 0;
    }
}
