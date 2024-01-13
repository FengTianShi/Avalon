using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStateReact", menuName = "Data/StateMachine/SkeletonState/React")]
public class SkeletonStateReact : SkeletonState
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
                StateMachine.SwitchState(typeof(SkeletonStateChase));
            }
            else
            {
                StateMachine.SwitchState(typeof(SkeletonStateIdle));
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
