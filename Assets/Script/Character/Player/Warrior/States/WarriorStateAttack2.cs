using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateAttack2", menuName = "Data/StateMachine/WarriorState/Attack2")]
public class WarriorStateAttack2 : WarriorState
{
    [SerializeField]
    float EnterSpeed;

    [SerializeField]
    float Deceleration;

    private bool IsContinueAttack;

    public override void Enter()
    {
        base.Enter();

        CurrentSpeed = EnterSpeed;

        IsContinueAttack = false;
    }

    public override void LogicUpdate()
    {
        EnterSpeed = Mathf.MoveTowards(EnterSpeed, 0, Deceleration * Time.deltaTime);

        if (Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (Input.IsAttack)
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
        Character.Move(CurrentSpeed);
    }

    public override void Exit()
    {
    }
}
