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
    public Direction currentDirection { get; private set; }
    [SerializeField] private GameObject trailObject;
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
        trailObject.SetActive(true);
        StartCoroutine(Trail());
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        trailObject.SetActive(false);
        endPosition = position;
        endTime = time;
        DetectSwipe();
        StopCoroutine(Trail());
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
            currentDirection = Direction.Up;
            EVT_OnSwipeUp.Invoke();

        }
        //Dot Product
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            currentDirection = Direction.Down;
            EVT_OnSwipeDown.Invoke();
        }
        //Dot Product
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            currentDirection = Direction.Left;
            EVT_OnSwipeLeft.Invoke();
        }
        //Dot Product
       else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            currentDirection = Direction.Right;
            EVT_OnSwipeRight.Invoke();
        }
    }

    private IEnumerator Trail()
    {
        while(true)
        {
            trailObject.transform.position = inputControllerObj.PrimaryPosition();
            yield return null;
        }
    }
}
