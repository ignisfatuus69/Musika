using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnObjectPooled : UnityEvent { };

[System.Serializable]
public class OnObjectSpawned : UnityEvent { };

public abstract class ObjectPooler : MonoBehaviour
{
    public OnObjectSpawned EVT_OnObjectSpawned;
    public OnObjectPooled EVT_OnObjectPooled;

    [SerializeField]private GameObject ObjectToSpawn;
    [SerializeField]private int SpawnCount = 1;


    protected List<GameObject> currentSpawnedObjects = new List<GameObject>();
    protected List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField]protected Vector3 SpawnPosition;

    private int totalNumberOfSpawnsCount = 0;

    public void Spawn()
    {
        for (int i = 0; i < SpawnCount; i++)
        {

            // Spawn the object. If we have an object in the pool, use that instead. Else, instantiate.
            GameObject obj;
            if (pooledObjects.Count > 0)
            {
                // get the last pooled object
                obj = pooledObjects[0];
                pooledObjects.RemoveAt(0);
                obj.SetActive(true);
                currentSpawnedObjects.Add(obj);

            }
            else
            {
                obj = Instantiate(ObjectToSpawn);
                currentSpawnedObjects.Add(obj);
                SetPoolingConditions(obj);
            }

            totalNumberOfSpawnsCount += 1;
            //Set Spawn Position
            obj.transform.position = SpawnPosition;

            EVT_OnObjectSpawned.Invoke();
        }
    }
    protected abstract void SetPoolingConditions(GameObject obj);

    protected virtual void Pool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        pooledObjects.Add(obj.gameObject);
        currentSpawnedObjects.Remove(obj.gameObject);
    }

}
