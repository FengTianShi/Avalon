using UnityEngine;

[CreateAssetMenu(fileName = "WarriorStateAttack3", menuName = "Data/StateMachine/WarriorState/Attack3")]
public class WarriorStateAttack3 : WarriorState
{
    [SerializeField]
    float enterSpeed;

    [SerializeField]
    float deceleration;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = enterSpeed;

        warrior.SetFacing();
    }

    public override void LogicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (input.Dash)
        {
            stateMachine.SwitchState(typeof(WarriorStateDash));
        }

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(WarriorStateIdle));
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
