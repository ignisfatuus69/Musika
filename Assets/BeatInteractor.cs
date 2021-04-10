using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using TMPro;
[System.Serializable]
public class OnBeatInteraction : UnityEvent<Beat> { };
public class BeatInteractor : MonoBehaviour
{
    public OnBeatInteraction EVT_OnBeatInteraction;
    [SerializeField] private SongData songDataToPlay;
    [SerializeField] private PlayableDirector songDirectorObj;
    [SerializeField] private BeatSpawner beatSpawnerObj;
    public TextMeshProUGUI tmProUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EvaluateBeatState(Beat beatToEvaluate)
    {
        if (songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 5))) return;
        EVT_OnBeatInteraction.Invoke(beatToEvaluate);
        
        //Debug.Log("Interacted");
        //Debug.Log("Beat Index:" + beatToEvaluate.index);
        //Debug.Log("CURRENT TIME:" + songDirectorObj.time);
        //Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatToEvaluate.index]);
        // Early State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 5))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)))
        {
            Debug.Log("Early");
            Debug.Log("Beat Number:" + beatToEvaluate.index);
            Debug.Log("Time Stamp:"+songDataToPlay.beatTimeStamps[beatToEvaluate.index]);
            beatToEvaluate.beatState = BeatState.Miss;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatToEvaluate.index]);
            Debug.Log("IS GREATER THAN:" +(songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));

        }
        // Okay State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 1.5f)))
        {
            Debug.Log("Okay");
            beatToEvaluate.beatState = BeatState.Okay;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatToEvaluate.index]);
            Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));
        }
        // Perfect State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 1.5f))
            && songDirectorObj.time < songDataToPlay.beatTimeStamps[beatToEvaluate.index] + songDataToPlay.GetOffsetBeatTime)
        {
            Debug.Log("Perfect");
            beatToEvaluate.beatState = BeatState.Perfect;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatToEvaluate.index]);
            Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));
        }
        tmProUI.text = beatToEvaluate.beatState.ToString();
        beatToEvaluate.BeatInteraction();
        // Late/End State
        // + despawn prolong time later
        //else if (songDirectorObj.time > songDataToPlay.beatTimeStamps[beatToEvaluate.index] + songDataToPlay.GetOffsetBeatTime)
        //{
        //    Debug.Log("Timed Out");
        //    beatToEvaluate.beatState = BeatState.Miss;

        //    Debug.Log("CURRENT TIME:" + songDirectorObj.time);
        //    Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatToEvaluate.index]);
        //    Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
        //    Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));
        //}
    }
}
