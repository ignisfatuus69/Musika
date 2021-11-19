using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEffectSpawner : ObjectPooler
{
    [SerializeField] public BeatSpawner beatSpawnerObj;
    public BeatState currentBeatState { get; private set; }

    private void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(SetCurrentBeatState);
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(SpawnBeatEffect);
    }

    private void SpawnBeatEffect(Beat beatObj)
    {
        if (beatObj.beatState == BeatState.Miss) return;
        CopyBeatPosition(beatObj);
        Spawn();
    }
    protected override void SetPoolingInitializations(GameObject obj)
    {
        BeatEffect beatEffect = obj.GetComponent<BeatEffect>();
        beatEffect.beatEffectSpawnerReference = this;
        beatEffect.EVT_OnDeactivate.AddListener(Pool);
    }

    private void SetCurrentBeatState(Beat beatObj)
    {
        currentBeatState = beatObj.beatState;
    }

    private void CopyBeatPosition(Beat beatObj)
    {
        this.SpawnPosition = beatObj.transform.position;
    }
}
