using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class OnStartTouch : UnityEvent<Vector2, float> { };
[System.Serializable]
public class OnEndTouch : UnityEvent<Vector2, float> { };

[DefaultExecutionOrder(-1)]
public class InputController : MonoBehaviour
{
    public OnStartTouch EVT_OnStartTouch;
    public OnEndTouch EVT_OnEndTouch;

    //public delegate void StartTouch(Vector2 position, float time);
    //public event StartTouch OnStartTouch;
    //public delegate void EndTouch(Vector2 position, float time);
    //public event EndTouch OnEndTouch;
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnEnable()
    {
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerRelease;
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= FingerRelease;
        TouchSimulation.Disable();
        
    }

    private void FingerDown(Finger finger)
    {
        if (EVT_OnStartTouch!=null) EVT_OnStartTouch.Invoke(finger.screenPosition, Time.time);
    }

    private void FingerRelease(Finger finger)
    {
        if (EVT_OnEndTouch != null) EVT_OnEndTouch.Invoke(finger.screenPosition, Time.time);
    }

}
