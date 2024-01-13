using UnityEngine;

[CreateAssetMenu(fileName = "UndeadStatePatrol", menuName = "Data/StateMachine/UndeadState/Patrol")]
public class UndeadStatePatrol : UndeadState
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
            StateMachine.SwitchState(typeof(UndeadStateIdle));
        }

        if (Enemy.Target != null)
        {
            StateMachine.SwitchState(typeof(UndeadStateReact));
        }
    }

    public override void PhysicUpdate()
    {
        Enemy.SetFacing(PatrolPoint);
        Undead.Move(MoveSpeed, PatrolPoint);
    }

    public override void Exit()
    {
    }
}
