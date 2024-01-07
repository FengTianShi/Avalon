using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateAttack3", menuName = "Data/StateMachine/WarriorState/Attack3")]
public class WarriorStateAttack3 : WarriorState
{
    [SerializeField]
    float EnterSpeed;

    [SerializeField]
    float Deceleration;

    public override void Enter()
    {
        base.Enter();

        CurrentSpeed = EnterSpeed;

        Player.SetFacing();
    }

    public override void LogicUpdate()
    {
        CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, 0, Deceleration * Time.deltaTime);

        if (Input.IsDash)
        {
            StateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (IsAnimationFinished)
        {
            StateMachine.SwitchState(typeof(WarriorStateIdle));
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
