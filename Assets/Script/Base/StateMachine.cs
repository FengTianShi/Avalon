using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState CurrentState;

    protected Dictionary<System.Type, IState> StateTable;

    void Update()
    {
        CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        CurrentState.PhysicUpdate();
    }

    protected void SwitchOn(IState newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void SwitchState(IState newState)
    {
        CurrentState.Exit();
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newStateType)
    {
        CurrentState.Exit();
        SwitchOn(StateTable[newStateType]);
    }
}
