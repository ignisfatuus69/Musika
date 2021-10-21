using System.Collections;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class OnSwipeUp : UnityEvent { };
[System.Serializable]
public class OnSwipeDown : UnityEvent { };
[System.Serializable]
public class OnSwipeRight : UnityEvent { };
[System.Serializable]
public class OnSwipeLeft : UnityEvent { };

public enum Direction { Left, Right, Up,Down };
public class SwipeDetection : MonoBehaviour
{
    public OnSwipeUp EVT_OnSwipeUp;
    public OnSwipeDown EVT_OnSwipeDown;
    public OnSwipeLeft EVT_OnSwipeLeft;
    public OnSwipeRight EVT_OnSwipeRight;

    [SerializeField] private InputController inputControllerObj;
    [SerializeField] private float minimumSwipeDistance = 0.2f;
    [SerializeField] private float maximumSwipeTime = 1f;
    [SerializeField,Range(0,1)] private float directionThreshold =0.9f;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private Direction currentDirection;
    private void OnEnable()
    {
        inputControllerObj.EVT_OnStartTouch.AddListener(SwipeStart);
        inputControllerObj.EVT_OnEndTouch.AddListener(SwipeEnd);
    }

    private void OnDisable()
    {
        inputControllerObj.EVT_OnStartTouch.RemoveListener(SwipeStart);
        inputControllerObj.EVT_OnEndTouch.RemoveListener(SwipeEnd);
    }
    private void SwipeStart(Vector2 position,float time)
    {
        startPosition = position;
        startTime = time;
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) < minimumSwipeDistance) return;
        if (endTime-startTime>maximumSwipeTime) return;

        Vector3 direction = endPosition - startPosition;
        Vector2 direction2d = new Vector2(direction.x, direction.y).normalized;
        Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
        DetermineDirection(direction2d);
    }

    private void DetermineDirection(Vector2 direction)
    {
        //Dot Product
        if(Vector2.Dot(Vector2.up,direction)>directionThreshold)
        {
            EVT_OnSwipeUp.Invoke();
            currentDirection = Direction.Up;
        }
        //Dot Product
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            EVT_OnSwipeDown.Invoke();
            currentDirection = Direction.Down;
        }
        //Dot Product
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            EVT_OnSwipeLeft.Invoke();
            currentDirection = Direction.Left;
        }
        //Dot Product
       else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            EVT_OnSwipeRight.Invoke();
            currentDirection = Direction.Right;
        }
    }
}
