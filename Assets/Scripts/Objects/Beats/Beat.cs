using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.Playables;

public enum BeatState { Okay, Perfect, Miss };

[System.Serializable]
public class OnInteracted : UnityEvent<Beat> { };
[System.Serializable]
public class OnBeatTimedOut : UnityEvent<Beat> { };
[System.Serializable]
public class OnDeactivate : UnityEvent<GameObject> { };
public class Beat : MonoBehaviour
{

    public OnInteracted EVT_OnInteracted;
    public OnBeatTimedOut EVT_OnTimedOut;
    public OnDeactivate EVT_OnDeactivate;
    public float beatTimer = 0;
    public bool isInteractable = true;
    public BeatState beatState = BeatState.Miss;
    public int index = 0;
    [SerializeField] private float finalOuterCircleScale;
    [SerializeField] private Transform outerCircle;
    [SerializeField] private Collider2D beatCollider;

    public float Timer = 0;
    private Vector3 originalOuterCircleScale = new Vector3(1, 1, 1);

    //TEMPORARY
    private PlayableDirector songDirectorObj;
    [SerializeField] private SongData songDataToPlay;
    private BeatSpawner beatSpawnerObj;
    private void Awake()
    {
        originalOuterCircleScale = outerCircle.localScale;
        songDirectorObj = GameObject.FindObjectOfType<PlayableDirector>();
        beatSpawnerObj = GameObject.FindObjectOfType<BeatSpawner>();
    }


    private void OnEnable()
    {
        //Reset values
        beatCollider.enabled = false;
        this.beatState = BeatState.Miss;
        outerCircle.localScale = originalOuterCircleScale;

        StartCoroutine(StartBeatTimer());
        outerCircle.DOScale(finalOuterCircleScale, beatTimer);
    }

    private void OnDisable()
    {
        this.beatState = BeatState.Miss;
        beatCollider.enabled = false;
    }


    //TEMPORARY CODE
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
    private void Update()
    {
        EnableCollider();
        SetBeatState();
    }


    private void EnableCollider()
    {
        if (this.index == 0)
        {
            beatCollider.enabled = true;
            return;
        }
        if (this.index <= beatSpawnerObj.totalPooledCount)
        {
            beatCollider.enabled = true;
        }
    }

    //TEMPORARY
    public void SetBeatState()
    {
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[this.index] + (songDataToPlay.GetOffsetBeatTime / 3.25f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[this.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)))
        {
            this.beatState = BeatState.Miss;

        }
        // Okay State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[this.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[this.index] + (songDataToPlay.GetOffsetBeatTime / 1.5f)))
        {
            this.beatState = BeatState.Okay;

        }
        // Perfect State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[this.index] + (songDataToPlay.GetOffsetBeatTime / 1.5f))
            && songDirectorObj.time < songDataToPlay.beatTimeStamps[this.index] + songDataToPlay.GetOffsetBeatTime)
        {
            this.beatState = BeatState.Perfect;

        }

        else if (songDirectorObj.time > songDataToPlay.beatTimeStamps[this.index] + songDataToPlay.GetOffsetBeatTime+0.25f)
        {
            this.beatState = BeatState.Miss;
        }

    }
    IEnumerator StartBeatTimer()
    {
        yield return new WaitForSeconds(beatTimer);
        gameObject.SetActive(false);
        EVT_OnTimedOut.Invoke(this);
        EVT_OnDeactivate.Invoke(this.gameObject);

    }

}
