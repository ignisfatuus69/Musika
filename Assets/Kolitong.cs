using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Kolitong : BeatInteractor
{
    [SerializeField] Camera cameraMain;
    [SerializeField] private InputController inputcontrollerObj;
    private KolitongBeat currentBeat;
    private List<Vector2> positionsToCast = new List<Vector2>();
    [SerializeField] private SwipeDetection swipeDetector;
    // Start is called before the first frame update
    void Start()
    {
        inputcontrollerObj.EVT_OnStartTouch.AddListener(StartTouch);
        inputcontrollerObj.EVT_OnHoldTouch.AddListener(OnTouchHold);
        inputcontrollerObj.EVT_OnEndTouch.AddListener(OnEndTouch);
    }


    protected virtual void StartTouch(Vector2 position,float time)
    {
        positionsToCast.Add(position);

    }
    protected virtual void OnTouchHold(Vector2 position,float time)
    {
        AddMorePositions(position);
    }
    protected virtual void OnEndTouch(Vector2 position,float time)
    {
        positionsToCast.Add(position);
        positionsToCast.Clear();
    }

    public override void EvaluateBeatState(Beat beatToEvaluate)
    {
        if (swipeDetector.currentDirection != currentBeat.beatDirection) return;
        base.EvaluateBeatState(beatToEvaluate);
    }
    public void DetectSwipe()
    {
        
        for (int i = 0; i < positionsToCast.Count; i++)
        {
            Vector3 screenCoordinates = new Vector3(positionsToCast[i].x, positionsToCast[i].y, cameraMain.nearClipPlane);
            Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
            worldCoordinates.z = -10;
            //Fire 
            Ray ray = new Ray(worldCoordinates, Vector3.forward);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 55, Color.green);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
            {
                KolitongBeat detectedKolitongBeat = hit.transform.gameObject.GetComponent<KolitongBeat>();
                currentBeat = detectedKolitongBeat;
                this.EvaluateBeatState(currentBeat);

            }
        }


    }

    void AddMorePositions(Vector2 position)
    {
        positionsToCast.Add(position);

    }
}
