using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnBeatPooled : UnityEvent<Beat> { };

[System.Serializable]
//public class OnBeatSpawned : UnityEvent<Beat> { };
public class BeatSpawner : ObjectPooler
{
    public OnBeatPooled EVT_OnBeatPooled;
    [SerializeField] private SongData songDataScriptableObject;
    [SerializeField] Transform[] spawnPoints;

    private void Start()
    {
        EVT_OnObjectSpawned.AddListener(SetBeatIndex);
    }

    public override void Spawn()
    {
        base.Spawn();
    }
    private void SetSpawnPosition()
    {
        SpawnPosition = spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalSpawnsCount]].position;
        Debug.Log(spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalSpawnsCount]]);
    }
    protected override void SetPoolingInitializations(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
     //   beatObj.EVT_OnDeactivate.AddListener(InvokePoolBeatEvent);
        beatObj.EVT_OnDeactivate.AddListener(PoolInSeconds);
    }
    private void PoolInSeconds(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        totalPooledCount += 1;
        EVT_OnBeatPooled.Invoke(beatObj);
        EVT_OnObjectPooled.Invoke(obj);
        StartCoroutine(DelayedPool(obj));
    }

    private void SetBeatIndex(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        beatObj.index = this.totalSpawnsCount-1;
    }

    IEnumerator DelayedPool(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        Pool(obj);
    }
}
