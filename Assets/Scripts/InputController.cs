using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class OnStartTouch : UnityEvent<Vector2, float> { };
[System.Serializable]
public class OnEndTouch : UnityEvent<Vector2, float> { };
[System.Serializable]
public class OnHoldTouch : UnityEvent<Vector2, float> { };

[DefaultExecutionOrder(-1)]
public class InputController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public OnStartTouch EVT_OnStartTouch;
    public OnEndTouch EVT_OnEndTouch;
    public OnHoldTouch EVT_OnHoldTouch;
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnEnable()
    {
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerRelease;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove += FingerHold;
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

    private void FingerHold(Finger finger)
    {
        if (EVT_OnHoldTouch != null) EVT_OnHoldTouch.Invoke(finger.screenPosition, Time.time);
    }
    private void FingerRelease(Finger finger)
    {
        if (EVT_OnEndTouch != null) EVT_OnEndTouch.Invoke(finger.screenPosition, Time.time);
    }

    public Vector2 PrimaryPosition()
    {
        if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count <= 0) return Vector2.zero;
        return Utilities.ScreenToWorld(mainCamera,UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers[UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count-1].screenPosition);
 
    }

}
