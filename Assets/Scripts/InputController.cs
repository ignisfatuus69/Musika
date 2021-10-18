using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputController : MonoBehaviour
{
    private Camera mainCamera;

    private PlayerControls playerControls;

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    private void Awake()
    {
        this.playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartPrimaryTouch(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndPrimaryTouch(ctx);
    }

    private void StartPrimaryTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utilities.ScreenToWorld(mainCamera,playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()),(float)context.startTime);
    }

    private void EndPrimaryTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utilities.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector2 PrimaryPosition()
    {
        return Utilities.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
