using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStatePatrol", menuName = "Data/StateMachine/SkeletonState/Patrol")]
public class SkeletonStatePatrol : SkeletonState
{
    [SerializeField]
    float MoveSpeed;

    Transform PatrolPoint;

    public override void Enter()
    {
        base.Enter();

        PatrolPoint = Enemy.GetPatrolPoint();
    }

    public override void LogicUpdate()
    {
        float positionX = Enemy.transform.position.x;

        if (Mathf.Abs(PatrolPoint.position.x - positionX) <= 0.1f)
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
