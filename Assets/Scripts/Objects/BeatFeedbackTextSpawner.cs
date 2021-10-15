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

    [SerializeField] private Sprite[] beatStateSprites; // 0 = miss, 1 = okay, 2=perfect

    private void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(SpawnFeedbackText);
    }
    private void SetSpriteToBeatState(Beat beatObj)
    {
        BeatFeedbackText beatFBTextObj = currentSpawnedObjects[currentSpawnedObjects.Count - 1].GetComponent<BeatFeedbackText>();

        if (beatObj.beatState == BeatState.Miss) beatFBTextObj.spriteRendererComponent.sprite = beatStateSprites[0];
        if (beatObj.beatState == BeatState.Okay) beatFBTextObj.spriteRendererComponent.sprite = beatStateSprites[1];
        if (beatObj.beatState == BeatState.Perfect) beatFBTextObj.spriteRendererComponent.sprite = beatStateSprites[2];

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
        SetSpriteToBeatState(beatObj);
    }

    private void CopyBeatPosition(Beat beatObj)
    {
        this.SpawnPosition = beatObj.transform.position;
    }
}
