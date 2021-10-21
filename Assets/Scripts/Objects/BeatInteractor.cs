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

    public virtual void EvaluateBeatState(Beat beatToEvaluate)
    {
        EVT_OnBeatInteraction.Invoke(beatToEvaluate);
        // Early State
        if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + 
            (songDataToPlay.GetOffsetBeatTime / 5))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + 
            (songDataToPlay.GetOffsetBeatTime / 2.5f)))
        {
            beatToEvaluate.beatState = BeatState.Miss;

        }
        // Okay State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + 
            (songDataToPlay.GetOffsetBeatTime / 2.5f))
            && songDirectorObj.time < (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + 
            (songDataToPlay.GetOffsetBeatTime / 1.5f)))
        {
            beatToEvaluate.beatState = BeatState.Okay;

        }
        // Perfect State
        else if (songDirectorObj.time > (songDataToPlay.beatTimeStamps[beatToEvaluate.index] + 
            (songDataToPlay.GetOffsetBeatTime / 1.5f))
            && songDirectorObj.time < songDataToPlay.beatTimeStamps[beatToEvaluate.index] + 
            songDataToPlay.GetOffsetBeatTime)
        {
            beatToEvaluate.beatState = BeatState.Perfect;

        }
        beatToEvaluate.BeatInteraction();
    }
}
