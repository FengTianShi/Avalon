using UnityEngine;

public class WarriorInput : MonoBehaviour
{
    WarriorInputActions warriorInputActions;

    Vector2 Axes => warriorInputActions.Gameplay.Axes.ReadValue<Vector2>();

    public float Horizontal => Axes.x;

    public float Vertical => Axes.y;

    public bool Move => Horizontal != 0;

    public bool Jump => warriorInputActions.Gameplay.Jump.WasPerformedThisFrame();

    public bool StopJump => warriorInputActions.Gameplay.Jump.WasReleasedThisFrame();

    public bool Dash => warriorInputActions.Gameplay.Dash.WasPerformedThisFrame();

    public bool Attack => warriorInputActions.Gameplay.Attack.WasPerformedThisFrame();

    void Awake()
    {
        warriorInputActions = new WarriorInputActions();
    }

    public void EnableGameplayInputs()
    {
        warriorInputActions.Gameplay.Enable();
        // Cursor.lockState = CursorLockMode.Locked;
    }
}
