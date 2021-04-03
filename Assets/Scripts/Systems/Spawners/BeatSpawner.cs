using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : ObjectPooler
{
    [SerializeField] private SongData songDataScriptableObject;
    [SerializeField] Transform[] spawnPoints;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spawn();
        }
    }
    public void SetSpawnPosition()
    {
        SpawnPosition = spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalNumberOfSpawnsCount]].position;
        Debug.Log(spawnPoints[songDataScriptableObject.beatNoteIndexes[this.totalNumberOfSpawnsCount]]);
    }
    protected override void SetPoolingInitializations(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        beatObj.EVT_OnDeactivate.AddListener(Pool);
    }

}
