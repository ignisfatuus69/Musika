using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnBeatPooled : UnityEvent<Beat> { };

[System.Serializable]
public class OnBeatSpawned : UnityEvent<Beat> { };
public class BeatSpawner : ObjectPooler
{
    public OnBeatSpawned EVT_OnBeatSpawned;
    public OnBeatPooled EVT_OnBeatPooled;
    [SerializeField] private SongData songDataScriptableObject;
    [SerializeField] Transform[] spawnPoints;

    protected virtual void Start()
    {
        EVT_OnObjectSpawned.AddListener(InvokeOnBeatSpawned);
        EVT_OnBeatSpawned.AddListener(SetBeatIndex);
    }

    public override void Spawn()
    {
        base.Spawn();
    }

    private void InvokeOnBeatSpawned(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        beatObj.beatSpawnerObj = this;
        beatObj.beatTimer = songDataScriptableObject.GetOffsetBeatTime;
        beatObj.gameObject.SetActive(true);
        EVT_OnBeatSpawned.Invoke(beatObj);
    }
    public void SetSpawnPosition()
    {
        SpawnPosition = spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalSpawnsCount]].position;
    }
    protected override void SetPoolingInitializations(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
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

    private void SetBeatIndex(Beat beatObj)
    {
        beatObj.index = this.totalSpawnsCount-1;
    }

    IEnumerator DelayedPool(GameObject obj)
    {
        yield return new WaitForSeconds(poolTimer);
        Pool(obj);
    }
}
