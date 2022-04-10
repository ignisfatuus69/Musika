using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class ComboLightingEffect : MonoBehaviour
{
    [SerializeField] private BeatInteractor beatInteractorObj = null;
    [SerializeField] private int[] comboNumbersToActivateEffect;
    [SerializeField] private Light2D[] comboLightingObjects;
    [SerializeField] private BeatSpawner beatSpawnerObj;
    [SerializeField] private Vector2 intensityMinMaxValues;
    [SerializeField] private Vector2 innerRadiusMinMaxValues;
    [SerializeField] private Vector2 outerRadiusMinMaxValues;

    private List<Coroutine> lightingEffectCoroutines = new List<Coroutine>();
    private int comboEffectCounter = 0;
    private int currentIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(ActivateEffect);
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(DisableEffect);
    }

    private void ActivateEffect(Beat beatObj)
    {
        if (beatObj.beatState == BeatState.Miss) return;

        if (comboLightingObjects[comboLightingObjects.Length - 1].gameObject.activeSelf) return;
        //if the last combo lighting is activated, skip
        comboEffectCounter += 1;

        if (comboEffectCounter==comboNumbersToActivateEffect[currentIndex])
        {
            comboLightingObjects[currentIndex].gameObject.SetActive(true);
            Debug.Log("natawag ka pre");
            comboEffectCounter = 0;
            currentIndex += 1;
        }
    }

    private void DisableEffect(Beat beatObj)
    {
        if (beatObj.beatState== BeatState.Miss)
        {
            comboEffectCounter = 0;
            currentIndex = 0;
            for (int i = 0; i < comboLightingObjects.Length; i++)
            {
                // if it isn't active, skip the rest
                if (!comboLightingObjects[i].gameObject.activeSelf) return;
                comboLightingObjects[i].GetComponent<ComboLightingEffectObject>().DeactivateLightingEffect();
            }
        }
    }



}
