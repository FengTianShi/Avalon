using UnityEngine;

public class PlayerController : CharacterController
{
    [HideInInspector]
    public PlayerInput Input;

    protected override void Awake()
    {
        base.Awake();

        Input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        Input.EnableGameplayInputs();
    }

    public void SetFacing()
    {
        if (Input.IsMove)
        {
            SetFacing(Input.XInput > 0);
        }
    }
}
