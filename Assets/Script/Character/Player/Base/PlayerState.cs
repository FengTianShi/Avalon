using UnityEngine;

public class PlayerState : CharacterState
{
    protected PlayerInput Input;

    protected PlayerController Player => (PlayerController)Character;

    protected float CurrentSpeed;

    public void Initialize(
        PlayerStateMachine stateMachine,
        PlayerController player,
        Animator animator,
        PlayerInput input)
    {
        Initialize(stateMachine, player, animator);
        Input = input;
    }
}
