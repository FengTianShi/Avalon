using System;
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

        if (Skeleton.IsPlayerInAttackRange())
        {
            StateMachine.SwitchState(typeof(SkeletonStateAttack));
        }
    }

    public override void PhysicUpdate()
    {
        Enemy.SetFacing(Enemy.Target);

        float positionX = Enemy.transform.position.x;

        if (Enemy.IsFacingRight && Math.Abs(positionX - Enemy.ChaseRange.Right) < 0.1f)
        {
            Animator.Play("Idle");
            Enemy.Stop();
            return;
        }

        if (!Enemy.IsFacingRight && Math.Abs(positionX - Enemy.ChaseRange.Left) < 0.1f)
        {
            Animator.Play("Idle");
            Enemy.Stop();
            return;
        }

        Animator.Play("Chase");
        Enemy.Move(MoveSpeed);
    }

    public override void Exit()
    {
    }
}
