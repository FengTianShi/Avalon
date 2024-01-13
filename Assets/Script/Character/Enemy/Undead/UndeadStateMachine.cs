public class UndeadStateMachine : EnemyStateMachine
{
    void Start()
    {
        SwitchOn(StateTable[typeof(UndeadStateIdle)]);
    }
}
