public class WitcherStateMachine : PlayerStateMachine
{
    void Start()
    {
        SwitchOn(StateTable[typeof(WitcherStateIdle)]);
    }
}
