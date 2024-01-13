using UnityEngine;

public class UndeadController : EnemyController
{
    public Transform AttackPoint;

    public float AttackRange;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    public bool IsPlayerInAttackRange()
    {
        return Physics2D.OverlapCircle(AttackPoint.position, AttackRange, PlayerLayer);
    }

    public void Move(float speed, Transform target)
    {
        Vector2 direction = target.position - transform.position;

        SetVelocity(direction.normalized * speed);
    }
}
