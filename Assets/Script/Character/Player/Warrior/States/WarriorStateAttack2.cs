using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateAttack2", menuName = "Data/StateMachine/WarriorState/Attack2")]
public class WarriorStateAttack2 : WarriorState
{
    [SerializeField]
    float EnterSpeed;

    [SerializeField]
    float Deceleration;

    bool IsContinueAttack;

    public override void Enter()
    {
        base.Enter();

        CurrentSpeed = EnterSpeed;

        IsContinueAttack = false;
    }

    public override void LogicUpdate()
    {
        CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, 0, Deceleration * Time.deltaTime);

        if (Player.Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Player.Input.IsAttack)
        {
            IsContinueAttack = true;
        }

        if (IsAnimationFinished)
        {
            if (IsContinueAttack)
            {
                StateMachine.SwitchState(typeof(WarriorStateAttack3));
            }
            else
            {
                StateMachine.SwitchState(typeof(WarriorStateIdle));
            }
        }
    }

    public override void PhysicUpdate()
    {
        Player.Move(CurrentSpeed);
    }

    public override void Exit()
    {
    }
}
