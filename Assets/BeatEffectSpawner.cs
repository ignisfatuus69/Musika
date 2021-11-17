using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEffectSpawner : ObjectPooler
{
    [SerializeField] private BeatSpawner beatSpawnerObj;


    private void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(SpawnBeatEffect);
    }
   
    protected override void SetPoolingInitializations(GameObject obj)
    {
        BeatEffect beatEffect = obj.GetComponent<BeatEffect>();
        beatEffect.EVT_OnDeactivate.AddListener(Pool);
    }

    private void SpawnBeatEffect(Beat beatObj)
    {
        if (beatObj.beatState == BeatState.Miss) return;
        CopyBeatPosition(beatObj);
        Spawn();
    }

    private void CopyBeatPosition(Beat beatObj)
    {
        this.SpawnPosition = beatObj.transform.position;
    }
}
