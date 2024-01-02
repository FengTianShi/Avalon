using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    Vector2 Axes => playerInputActions.Gameplay.Axes.ReadValue<Vector2>();

    public float Horizontal => Axes.x;

    public float Vertical => Axes.y;

    public bool Move => Horizontal != 0;

    public bool Jump => playerInputActions.Gameplay.Jump.WasPerformedThisFrame();

    public bool StopJump => playerInputActions.Gameplay.Jump.WasReleasedThisFrame();

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    public void EnableGameplayInputs()
    {
        playerInputActions.Gameplay.Enable();
        // Cursor.lockState = CursorLockMode.Locked;
    }
}
