using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

//[System.Serializable]
//public class OnFeedbackTextSpawn : UnityEvent<BeatFeedbackText> { };
public class BeatFeedbackTextSpawner : ObjectPooler
{

    [SerializeField] private Transform canvasTransform;
    [SerializeField] private BeatSpawner beatSpawnerObj;
    private void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(SpawnFeedbackText);
    }
    private void SetTextToBeat(Beat beatObj)
    {
        BeatFeedbackText beatFBTextObj = currentSpawnedObjects[currentSpawnedObjects.Count - 1].GetComponent<BeatFeedbackText>();
        beatFBTextObj.tmProComponent.text = beatObj.beatState.ToString();
    }
    protected override void SetPoolingInitializations(GameObject obj)
    {
        BeatFeedbackText beatFbTextObj = obj.GetComponent<BeatFeedbackText>();
        beatFbTextObj.EVT_OnDeactivate.AddListener(Pool);
    }

    private void SpawnFeedbackText(Beat beatObj)
    {
        CopyBeatPosition(beatObj);
        Spawn();
        SetParent();
        SetTextToBeat(beatObj);
    }

    private void SetParent()
    {
        currentSpawnedObjects[currentSpawnedObjects.Count - 1].transform.parent = canvasTransform;
    }

    private void CopyBeatPosition(Beat beatObj)
    {
        this.SpawnPosition = beatObj.transform.position;
    }
}
