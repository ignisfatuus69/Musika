using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;
using UnityEngine.Playables;
[System.Serializable]
public class OnBeatInteraction : UnityEvent<Beat> { };
public class BeatInteractor : MonoBehaviour
{
    public OnBeatInteraction EVT_OnBeatInteraction;
    [SerializeField] private SongData songDataToPlay;
    [SerializeField] private PlayableDirector songDirectorObj;
    [SerializeField] private BeatSpawner beatSpawnerObj;
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
        EVT_OnBeatInteraction.Invoke(beatToEvaluate);
        beatToEvaluate.BeatInteraction();
        
        Debug.Log("Interacted");
        Debug.Log("CURRENT TIME:" + songDirectorObj.time);
        Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);
        Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
        Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));

        // Early State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)))
        {
            Debug.Log("Early");
            Debug.Log("Beat Number:" + beatToEvaluate.index);
            Debug.Log("Time Stamp:"+songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);
            beatToEvaluate.beatState = BeatState.Miss;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);
            Debug.Log("IS GREATER THAN:" +(songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));

        }
        // Okay State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 1.5f)))
        {
            //
            Debug.Log("Okay");
            beatToEvaluate.beatState = BeatState.Okay;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);
            Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));
        }
        // Perfect State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 1.5f))
            && songDirectorObj.time < songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + songDataToPlay.GetOffsetBeatTime)
        {
            //
            Debug.Log("Perfect");
            beatToEvaluate.beatState = BeatState.Perfect;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);
            Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));
        }
        // Late/End State
        // + despawn prolong time later
        else if (songDirectorObj.time > songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + songDataToPlay.GetOffsetBeatTime)
        {
            Debug.Log("Timed Out");
            beatToEvaluate.beatState = BeatState.Miss;

            Debug.Log("CURRENT TIME:" + songDirectorObj.time);
            Debug.Log("BEAT REFERENCE TIME:" + songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);
            Debug.Log("IS GREATER THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f)));
            Debug.Log("IS LESS THAN:" + (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)));
        }
    }
}
