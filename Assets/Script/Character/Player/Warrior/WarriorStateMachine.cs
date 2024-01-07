public class WarriorStateMachine : PlayerStateMachine
{
    void Start()
    {
        SwitchOn(StateTable[typeof(WarriorStateIdle)]);
    }
}
