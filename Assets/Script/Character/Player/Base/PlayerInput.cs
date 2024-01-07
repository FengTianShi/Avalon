using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions PlayerInputActions;

    Vector2 Axes => PlayerInputActions.Gameplay.Axes.ReadValue<Vector2>();

    public float XInput => Axes.x;

    public float YInput => Axes.y;

    public bool IsMove => XInput != 0;

    public bool IsJump => PlayerInputActions.Gameplay.Jump.WasPerformedThisFrame();

    public bool IsStopJump => PlayerInputActions.Gameplay.Jump.WasReleasedThisFrame();

    public bool IsDash => PlayerInputActions.Gameplay.Dash.WasPerformedThisFrame();

    public bool IsAttack => PlayerInputActions.Gameplay.Attack.WasPerformedThisFrame();

    void Awake()
    {
        PlayerInputActions = new PlayerInputActions();
    }

    public void EnableGameplayInputs()
    {
        PlayerInputActions.Gameplay.Enable();
        // Cursor.lockState = CursorLockMode.Locked;
    }
}
