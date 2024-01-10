using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonStateIdle", menuName = "Data/StateMachine/SkeletonState/Idle")]
public class SkeletonStateIdle : SkeletonState
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
            StateMachine.SwitchState(typeof(SkeletonStatePatrol));
        }
    }

    public override void PhysicUpdate()
    {
    }

    public override void Exit()
    {
        Timer = 0;
    }
}
