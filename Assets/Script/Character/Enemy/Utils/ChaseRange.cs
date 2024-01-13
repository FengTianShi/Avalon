using UnityEngine;

public class ChaseRange
{
    public float Top = float.MaxValue;

    public float Bottom = float.MinValue;

    public float Right = float.MaxValue;

    public float Left = float.MinValue;

    public ChaseRange(Transform Top = null, Transform Bottom = null, Transform Right = null, Transform Left = null)
    {
        if (Top != null)
        {
            this.Top = Top.position.y;
        }

        if (Bottom != null)
        {
            this.Bottom = Bottom.position.y;
        }

        if (Right != null)
        {
            this.Right = Right.position.x;
        }

        if (Left != null)
        {
            this.Left = Left.position.x;
        }
    }
}