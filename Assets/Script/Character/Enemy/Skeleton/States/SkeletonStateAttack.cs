using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStateAttack", menuName = "Data/StateMachine/SkeletonState/Attack")]
public class SkeletonStateAttack : SkeletonState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            StateMachine.SwitchState(typeof(SkeletonStateChase));
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
