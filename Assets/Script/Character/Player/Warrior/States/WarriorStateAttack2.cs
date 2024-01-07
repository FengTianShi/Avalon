using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateAttack2", menuName = "Data/StateMachine/WarriorState/Attack2")]
public class WarriorStateAttack2 : WarriorState
{
    [SerializeField]
    float enterSpeed;

    [SerializeField]
    float deceleration;

    private bool isContinueAttack;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = enterSpeed;

        isContinueAttack = false;
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (input.Attack)
        {
            isContinueAttack = true;
        }

        if (IsAnimationFinished)
        {
            if (isContinueAttack)
            {
                stateMachine.SwitchState(typeof(WarriorStateAttack3));
            }
            else
            {
                stateMachine.SwitchState(typeof(WarriorStateIdle));
            }
        }
    }

    public override void PhysicUpdate()
    {
        warrior.Move(currentSpeed);
    }

    public override void Exit()
    {
    }
}
