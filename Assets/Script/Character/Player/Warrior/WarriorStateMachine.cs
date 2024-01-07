using System.Collections.Generic;
using UnityEngine;

public class WarriorStateMachine : StateMachine
{
    [SerializeField]
    WarriorState[] states;

    WarriorInput input;

    WarriorController warrior;

    Animator animator;

    void Awake()
    {
        input = GetComponent<WarriorInput>();

        warrior = GetComponent<WarriorController>();

        animator = GetComponentInChildren<Animator>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (WarriorState state in states)
        {
            state.Initialize(this, input, warrior, animator);
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(WarriorStateIdle)]);
    }
}
