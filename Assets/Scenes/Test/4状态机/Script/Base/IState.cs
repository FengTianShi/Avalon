using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void LogicUpdate();
    void PhysicUpdate();
    void Exit();
}
