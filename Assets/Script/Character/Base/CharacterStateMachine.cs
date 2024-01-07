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
        Animator = GetComponentInChildren<Animator>();

        Character = GetComponent<CharacterController>();

        StateTable = new Dictionary<System.Type, IState>(States.Length);

        foreach (CharacterState state in States)
        {
            state.Initialize(this, Character, Animator);
            StateTable.Add(state.GetType(), state);
        }
    }
}
