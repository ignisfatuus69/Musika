using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public enum BeatState { Okay, Perfect, Miss };

[System.Serializable]
public class OnInteracted : UnityEvent<Beat> { };
[System.Serializable]
public class OnTimedOut : UnityEvent<Beat> { };
[System.Serializable]
public class OnDeactivate : UnityEvent<GameObject> { };
public class Beat : MonoBehaviour
{

    public OnInteracted EVT_OnInteracted;
    public OnTimedOut EVT_OnTimedOut;
    public OnDeactivate EVT_OnDeactivate;
    public float beatTimer = 0;
    public bool isInteractable = false;
    public BeatState beatState = BeatState.Miss;



    [SerializeField] private float finalOuterCircleScale;
    [SerializeField]private Transform outerCircle;

    private Vector3 originalOuterCircleScale = new Vector3(1, 1, 1);

    private void Start()
    {
        originalOuterCircleScale = outerCircle.localScale;
        this.EVT_OnDeactivate.AddListener(Test);
    }
    private void OnEnable()
    {
        StartCoroutine(StartBeatTimer());
    }

    private void Test(GameObject obj)
    {
        Debug.Log("test");
    }
    private void OnDisable()
    {
        outerCircle.localScale = originalOuterCircleScale;
    }
    public void InteractBeat()
    {
        StopCoroutine(StartBeatTimer());
        EVT_OnInteracted.Invoke(this);
        EVT_OnDeactivate.Invoke(this.gameObject);
        this.gameObject.SetActive(false);
    }



    IEnumerator StartBeatTimer()
    {
        outerCircle.DOScale(finalOuterCircleScale, beatTimer);
        yield return new WaitForSeconds(beatTimer);
        EVT_OnTimedOut.Invoke(this);
        EVT_OnDeactivate.Invoke(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
