using UnityEngine;

[CreateAssetMenu(fileName = "WitcherStateAttack", menuName = "Data/StateMachine/WitcherState/Attack")]
public class WitcherStateAttack : WitcherState
{
    [SerializeField]
    float EnterSpeed;

    [SerializeField]
    float Deceleration;

    public override void Enter()
    {
        base.Enter();

        CurrentSpeed = EnterSpeed;
    }

    public override void LogicUpdate()
    {
        CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, 0, Deceleration * Time.deltaTime);

        if (IsAnimationFinished)
        {
            StateMachine.SwitchState(typeof(WitcherStateIdle));
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
