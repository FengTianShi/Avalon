public class SkeletonStateMachine : EnemyStateMachine
{
    void Start()
    {
        SwitchOn(StateTable[typeof(SkeletonStateIdle)]);
    }
}
