using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : Resource
{
    [SerializeField] private float easyBaseDeductionValue= 20;
    [SerializeField] private float mediumBaseDeductionValue = 75;
    [SerializeField] private float hardBaseDeductionValue = 150;
    [SerializeField] private BeatSpawner beatSpawnerObj;
    [SerializeField] private GameManager gameManagerObj;

    private float baseDeductionValue=0;
    private float multiplierNumber = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        currentValue = maximumValue;
        SetDeductionValueOnDifficulty();
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(ReduceLifeOnMiss);
    }

    private void ReduceLifeOnMiss(Beat beatObj)
    {
        if (beatObj.beatState != BeatState.Miss) return;

        baseDeductionValue *= multiplierNumber;
        this.currentValue -= baseDeductionValue;
        OnValueModified();
        EVT_OnValueDeducted.Invoke();
    }

    private void SetDeductionValueOnDifficulty()
    {
        if (gameManagerObj.GetSongDifficulty == SongDifficulty.Easy) baseDeductionValue = easyBaseDeductionValue;
        if (gameManagerObj.GetSongDifficulty == SongDifficulty.Medium) baseDeductionValue = mediumBaseDeductionValue;
        if (gameManagerObj.GetSongDifficulty == SongDifficulty.Hard) baseDeductionValue = hardBaseDeductionValue;
    }

 


}
