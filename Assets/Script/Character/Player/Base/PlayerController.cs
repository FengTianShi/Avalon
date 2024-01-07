public class PlayerController : CharacterController
{
    protected PlayerInput Input;

    protected override void Awake()
    {
        base.Awake();

        Input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        Input.EnableGameplayInputs();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SetFacing()
    {
        if (Input.IsMove)
        {
            SetFacing(Input.XInput > 0);
        }
    }
}
