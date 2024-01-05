public interface IState
{
    void Enter();

    void LogicUpdate();

    void PhysicUpdate();

    void Exit();
}
