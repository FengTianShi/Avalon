using UnityEngine;

[CreateAssetMenu(fileName = "UndeadStateReact", menuName = "Data/StateMachine/UndeadState/React")]
public class UndeadStateReact : UndeadState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            if (Enemy.Target != null)
            {
                StateMachine.SwitchState(typeof(UndeadStateChase));
            }
            else
            {
                StateMachine.SwitchState(typeof(UndeadStateIdle));
            }
        }
    }

    public override void PhysicUpdate()
    {
        Enemy.Stop();
    }

    public override void Exit()
    {
    }
}
