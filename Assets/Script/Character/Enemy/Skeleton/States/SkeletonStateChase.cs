using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStateChase", menuName = "Data/StateMachine/SkeletonState/Chase")]
public class SkeletonStateChase : SkeletonState
{
    [SerializeField]
    float MoveSpeed;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (Enemy.Target == null)
        {
            StateMachine.SwitchState(typeof(SkeletonStateIdle));
        }
    }

    public override void PhysicUpdate()
    {
        Enemy.SetFacing(Enemy.Target);
        Enemy.Move(MoveSpeed);
    }

    public override void Exit()
    {
    }
}
