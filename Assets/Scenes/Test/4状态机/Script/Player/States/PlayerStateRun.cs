using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateRun", menuName = "Data/StateMachine/PlayerState/Run")]
public class PlayerStateRun : PlayerState
{
    [SerializeField]
    float runSpeed = 5;

    [SerializeField]
    float acceration = 5;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = Mathf.Abs(player.XSpeed);
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerStateBrake));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        if (input.Move)
        {
            player.transform.localScale = new Vector3(input.Horizontal, 1, 1);
        }

        if (player.Slope != Vector2.zero)
        {
            player.SetVelocity(-input.Horizontal * currentSpeed * player.Slope);
        }
        else
        {
            if (player.YSpeed > 0)
            {
                player.SetVelocityY(0);
            }

            player.SetVelocityX(input.Horizontal * currentSpeed);
        }
    }

    public override void Exit()
    {
    }
}
