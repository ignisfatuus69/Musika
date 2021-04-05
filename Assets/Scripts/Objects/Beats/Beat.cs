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
    public int index = 0;
    [SerializeField] private float finalOuterCircleScale;
    [SerializeField]private Transform outerCircle;
    public float Timer = 0;
    private Vector3 originalOuterCircleScale = new Vector3(1, 1, 1);

    private void Awake()
    {
        originalOuterCircleScale = outerCircle.localScale;
    }
    private void OnEnable()
    {
        //Reset Values
        outerCircle.localScale = originalOuterCircleScale;


        StartCoroutine(StartBeatTimer());
        outerCircle.DOScale(finalOuterCircleScale, beatTimer);
    }

    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<BeatInteractor>().EvaluateBeatState(this);
    }
    public void BeatInteraction()
    {
        EVT_OnInteracted.Invoke(this);
        EVT_OnDeactivate.Invoke(this.gameObject);
        gameObject.SetActive(false);
       
    }
    IEnumerator StartBeatTimer()
    {
        yield return new WaitForSeconds(beatTimer);
        gameObject.SetActive(false);
        EVT_OnTimedOut.Invoke(this);
        EVT_OnDeactivate.Invoke(this.gameObject);

    }

}
