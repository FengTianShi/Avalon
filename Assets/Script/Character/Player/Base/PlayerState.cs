public class PlayerState : CharacterState
{
    protected PlayerController Player => (PlayerController)Character;

    protected float CurrentSpeed;
}
