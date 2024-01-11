using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStatePatrol", menuName = "Data/StateMachine/SkeletonState/Patrol")]
public class SkeletonStatePatrol : SkeletonState
{
    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    float PatrolCheckDistance = 0.1f;

    Transform PatrolPoint;

    public override void Enter()
    {
        base.Enter();

        PatrolPoint = Enemy.GetCurrentPatrolPoint();
    }

    public override void LogicUpdate()
    {
        float positionX = Enemy.transform.position.x;

        if (Mathf.Abs(PatrolPoint.position.x - positionX) <= PatrolCheckDistance)
        {
            StateMachine.SwitchState(typeof(SkeletonStateIdle));
        }

        if (Enemy.Target != null)
        {
            StateMachine.SwitchState(typeof(SkeletonStateReact));
        }
    }

    public override void PhysicUpdate()
    {
        Enemy.SetFacing(PatrolPoint);
        Enemy.Move(MoveSpeed);
    }

    public override void Exit()
    {
    }
}
