using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SongGrade
{
    SS=0,
    S=1,
    A=2,
    B=3,
    C=4,
    D=5,
    F=6,

}

public class Score : Resource
{
    [SerializeField] private BeatSpawner beatSpawnerObj;
    [SerializeField] private Combo comboCounterObj;
    [SerializeField] private int perfectScoreValue;
    [SerializeField] private int okayScoreValue;

    public int GetPerfectScoreValue => perfectScoreValue;
    public int GetOkayScoreValue => okayScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(AddScore);
    }

    void AddScore(Beat beatObj)
    {
        if (beatObj.beatState == BeatState.Miss) return;
        if (beatObj.beatState == BeatState.Okay) this.currentValue += (int) (okayScoreValue +  (okayScoreValue * ((comboCounterObj.currentValue-1) * 0.1) / 10));
        else if (beatObj.beatState == BeatState.Perfect) this.currentValue += (int)(perfectScoreValue + ((perfectScoreValue * (comboCounterObj.currentValue-1) * 0.1) / 10));

        OnValueModified();
        EVT_OnValueAdded.Invoke();
    }
}
