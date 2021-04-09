using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnBeatPooled : UnityEvent<Beat> { };

public class BeatSpawner : ObjectPooler
{
    public OnBeatPooled EVT_OnBeatPooled;
    [SerializeField] private SongData songDataScriptableObject;
    [SerializeField] Transform[] spawnPoints;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spawn();
        }
    }
    protected override void SetSpawnPosition()
    {
        SpawnPosition = spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalNumberOfSpawnsCount]].position;
        Debug.Log(spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalNumberOfSpawnsCount]]);
    }
    protected override void SetPoolingInitializations(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        beatObj.EVT_OnDeactivate.AddListener(InvokePoolBeatEvent);
        beatObj.EVT_OnDeactivate.AddListener(PoolInSeconds);
    }

    private void InvokePoolBeatEvent(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        EVT_OnBeatPooled.Invoke(beatObj);
    }
    private void PoolInSeconds(GameObject obj)
    {

        StartCoroutine(DelayedPool(obj));
    }

    IEnumerator DelayedPool(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        Pool(obj);
    }
}
