using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStatePatrol", menuName = "Data/StateMachine/SkeletonState/Patrol")]
public class SkeletonStatePatrol : SkeletonState
{
    [SerializeField]
    float MoveSpeed;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicUpdate()
    {
        Enemy.SetFacing(Enemy.PatrolPoints[Enemy.PatrolPosition]);
        Enemy.Move(MoveSpeed);
    }

    public override void Exit()
    {
    }
}
