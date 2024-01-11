using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : CharacterController
{
    public List<Transform> PatrolPoints;

    protected int PatrolPointIndex;

    public Transform GetCurrentPatrolPoint()
    {
        if (PatrolPointIndex >= PatrolPoints.Count)
        {
            PatrolPointIndex = 0;
        }

        Transform patrolPoint = PatrolPoints[PatrolPointIndex];

        PatrolPointIndex++;

        return patrolPoint;
    }

    public Transform Target;

    public LayerMask PlayerLayer;

    public float PlayerCheckDistance;

    public int PlayerCheckAngle;

    protected override void Update()
    {
        base.Update();

        if (Target == null)
        {
            CheckPlayer(PlayerCheckDistance, PlayerCheckAngle);
        }
        else
        {
            CheckPlayer(PlayerCheckDistance * 2, 180);
        }
    }

    protected virtual void CheckPlayer(float playerCheckDistance, int playerCheckAngle)
    {
        Bounds bounds = CC.bounds;
        Vector2 origin = new(bounds.min.x, bounds.center.y);
        float intervalDegree = 1;

        LayerMask layer = GroundLayer | PlayerLayer;

        for (int i = 0; i < playerCheckAngle; i++)
        {
            Vector2 direction = Quaternion.Euler(0, 0, intervalDegree * i)
                * (IsFacingRight ? Vector2.right : Vector2.left);

            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                direction,
                playerCheckDistance,
                layer);

            Debug.DrawRay(origin, direction * playerCheckDistance, Color.red);

            if (hit && hit.transform.CompareTag("Player"))
            {
                Target = hit.transform;
                return;
            }

            direction.y *= -1;

            hit = Physics2D.Raycast(
                origin,
                direction,
                playerCheckDistance,
                layer);

            Debug.DrawRay(origin, direction * playerCheckDistance, Color.red);

            if (hit && hit.transform.CompareTag("Player"))
            {
                Target = hit.transform;
                return;
            }
        }

        Target = null;
    }
}
