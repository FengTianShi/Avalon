using UnityEngine;

public class SkeletonController : EnemyController
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
}
