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
        // Early State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 3.25f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f)))
        {
            Debug.Log("Early");
            Debug.Log("Beat Number:" + beatToEvaluate.index);
            Debug.Log("Time Stamp:"+songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount]);

        }
        // Okay State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 2.5f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 1.5f)))
        {
            //
            Debug.Log("Okay");
        }
        // Perfect State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + (songDataToPlay.GetOffsetBeatTime / 1.5f))
            && songDirectorObj.time < songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + songDataToPlay.GetOffsetBeatTime)
        {
            //
            Debug.Log("Perfect");
        }
        // Late/End State
        // + despawn prolong time later
        if (songDirectorObj.time > songDataToPlay.beatTimeStamps[beatSpawnerObj.totalNumberOfSpawnsCount] + songDataToPlay.GetOffsetBeatTime)
        {
            Debug.Log("endbruh");
        }
    }
}
