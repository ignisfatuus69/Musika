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

    protected void EvaluateBeatState(Beat beatToEvaluate)
    {
        EVT_OnBeatInteraction.Invoke(beatToEvaluate);
        beatToEvaluate.BeatInteraction();
        // Early State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 3.25f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + (songDataToPlay.GetOffsetBeatTime / 2.5f)))
        {
            Debug.Log("Early");
            Debug.Log("Beat Number:" + beatToEvaluate.index);
            Debug.Log("Time Stamp:"+songDataToPlay.beatTimeStamps[beatToEvaluate.index]);

        }
    }
}
