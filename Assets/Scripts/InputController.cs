using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;

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
        EnhancedTouchSupport.Enable();
    }

    private void OnEnable()
    {
        // playerControls.Enable();
        //UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        //playerControls.Disable(); 
        TouchSimulation.Disable();
      //  UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerRelease;
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerControls.Touch.PrimaryContact.started += ctx => StartPrimaryTouch(ctx);
        //playerControls.Touch.PrimaryContact.canceled += ctx => EndPrimaryTouch(ctx);

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerRelease;
    }

    private void FingerDown(Finger finger)
    {
        if (OnStartTouch != null) OnStartTouch(finger.screenPosition, Time.time);
    }

    private void FingerRelease(Finger finger)
    {
        if (OnEndTouch != null) OnEndTouch(finger.screenPosition, Time.time);
    }

}
