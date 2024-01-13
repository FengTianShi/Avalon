using UnityEngine;

[CreateAssetMenu(fileName = "UndeadStateAttack", menuName = "Data/StateMachine/UndeadState/Attack")]
public class UndeadStateAttack : UndeadState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            StateMachine.SwitchState(typeof(UndeadStateChase));
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
