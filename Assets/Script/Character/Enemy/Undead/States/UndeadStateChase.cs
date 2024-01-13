using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UndeadStateChase", menuName = "Data/StateMachine/UndeadState/Chase")]
public class UndeadStateChase : UndeadState
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
            StateMachine.SwitchState(typeof(UndeadStateIdle));
        }

        if (Undead.IsPlayerInAttackRange())
        {
            StateMachine.SwitchState(typeof(UndeadStateAttack));
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
        Undead.Move(MoveSpeed, Enemy.Target);
    }

    public override void Exit()
    {
    }
}
