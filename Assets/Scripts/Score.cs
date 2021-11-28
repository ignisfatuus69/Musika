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
    [SerializeField] private SongData songData;
    [SerializeField] private BeatSpawner beatSpawnerObj;
    [SerializeField] private Combo comboCounterObj;
    [SerializeField] private int perfectScoreValue;
    [SerializeField] private int okayScoreValue;
    [SerializeField] public Resource missCounter;
    [SerializeField] public Resource goodCounter;
    [SerializeField] public Resource perfectCounter;

    public SongGrade songGrade { get; private set; }

    public int GetPerfectScoreValue => perfectScoreValue;
    public int GetOkayScoreValue => okayScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(AddScore);
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(DetermineSongGrade);
    }

    void AddScore(Beat beatObj)
    {
        if (beatObj.beatState == BeatState.Miss)
        {
            if (beatObj.beatState == BeatState.Miss) missCounter.currentValue += 1;
            missCounter.EVT_OnValueModified.Invoke();
            return;
        }

        if (beatObj.beatState == BeatState.Okay)
        {
            goodCounter.currentValue += 1;
            goodCounter.EVT_OnValueModified.Invoke();
            this.currentValue += (int)(okayScoreValue + (okayScoreValue * ((comboCounterObj.currentValue - 1) * 0.1) / 10));

        }
        else if (beatObj.beatState == BeatState.Perfect)
        {
            perfectCounter.currentValue += 1;
            perfectCounter.EVT_OnValueModified.Invoke();
            this.currentValue += (int)(perfectScoreValue + ((perfectScoreValue * (comboCounterObj.currentValue - 1) * 0.1) / 10));
        }
        OnValueModified();
        EVT_OnValueAdded.Invoke();
    }


    void DetermineSongGrade(Beat beatObj)
    {
        if (perfectCounter.currentValue >= songData.beatNoteIndexes.Count)
        {
            this.songGrade = SongGrade.SS;
            return;
        }

        if (perfectCounter.currentValue >= (songData.beatNoteIndexes.Count*0.9))
        {
            this.songGrade = SongGrade.SS;
            return;
        }

        if (perfectCounter.currentValue >= (songData.beatNoteIndexes.Count * 0.85))
        {
            this.songGrade = SongGrade.A;
            return;
        }
        if (perfectCounter.currentValue >= (songData.beatNoteIndexes.Count * 75))
        {
            this.songGrade = SongGrade.B;
            return;
        }
        else
        {
            this.songGrade = SongGrade.F;
            return;
        }


    }


}
