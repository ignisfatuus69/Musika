﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.LWRP;
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light2D globalLighting;
    [SerializeField]private Light2D gabbangLighting;
    [SerializeField] private Light2D[] lightingEffects; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetStartingSceneLighting());
    }

    IEnumerator SetStartingSceneLighting()
    {
        DOTween.To(() => globalLighting.intensity, x => globalLighting.intensity = x, 0.25f, 3);
        yield return new WaitForSeconds(4);
        DOTween.To(() => gabbangLighting.intensity, x => gabbangLighting.intensity = x, 0.8f, 2);
    }
}