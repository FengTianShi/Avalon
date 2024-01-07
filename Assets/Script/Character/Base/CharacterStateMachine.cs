using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    [SerializeField]
    protected CharacterState[] States;

    protected CharacterController Character;

    protected Animator Animator;

    protected virtual void Awake()
    {
        Character = GetComponent<CharacterController>();

        Animator = GetComponentInChildren<Animator>();

        StateTable = new Dictionary<System.Type, IState>(States.Length);

        InitializeStates();
    }

    protected virtual void InitializeStates()
    {
        foreach (CharacterState state in States)
        {
            state.Initialize(this, Character, Animator);
            StateTable.Add(state.GetType(), state);
        }
    }
}
