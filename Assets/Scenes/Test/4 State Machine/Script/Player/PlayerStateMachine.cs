using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField]
    PlayerState[] states;

    PlayerInput input;

    PlayerController player;

    Animator animator;

    void Awake()
    {
        input = GetComponent<PlayerInput>();

        player = GetComponent<PlayerController>();

        animator = GetComponentInChildren<Animator>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(this, input, player, animator);
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(PlayerStateIdle)]);
    }
}