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
    [SerializeField] private GameObject trailObj;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private void OnEnable()
    {
        inputControllerObj.OnStartTouch += SwipeStart;
        inputControllerObj.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputControllerObj.OnStartTouch -= SwipeStart;
        inputControllerObj.OnEndTouch -= SwipeEnd;
    }
    private void SwipeStart(Vector2 position,float time)
    {
        startPosition = position;
        startTime = time;
        trailObj.SetActive(true);
        trailObj.transform.position = position;
        StartCoroutine(trackTrail());
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
        trailObj.SetActive(false);
        StopCoroutine(trackTrail());
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
            Debug.Log("SwipeUp");
            EVT_OnSwipeUp.Invoke();
        }
        //Dot Product
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("SwipeDown");
            EVT_OnSwipeDown.Invoke();
        }
        //Dot Product
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("SwipeLeft");
            EVT_OnSwipeLeft.Invoke();
        }
        //Dot Product
       else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("SwipeRight");
            EVT_OnSwipeRight.Invoke();
        }
    }

    private IEnumerator trackTrail()
    {
        while(true)
        {
            trailObj.transform.position = inputControllerObj.PrimaryPosition();
            yield return null;
        }
    }
}
