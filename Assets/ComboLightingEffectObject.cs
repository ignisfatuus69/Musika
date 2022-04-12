using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;  
public class ComboLightingEffectObject : MonoBehaviour
{
    [SerializeField] private Light2D light2DComponent;
    [SerializeField] private Vector2 intensityMinMaxValues;
    [SerializeField] private Vector2 innerRadiusMinMaxValues;
    [SerializeField] private Vector2 outerRadiusMinMaxValues;
    private Coroutine lightingEffectCoroutine;
    private Coroutine dimOffLightingEffectCoroutine;

    private void OnEnable()
    {
        lightingEffectCoroutine = StartCoroutine(ActivateLightingEffects(light2DComponent, 1));
    }

    public void DeactivateLightingEffect()
    {
       StopCoroutine(lightingEffectCoroutine);
        dimOffLightingEffectCoroutine = StartCoroutine(DimOffLightingEffect(light2DComponent));
    }

    IEnumerator DimOffLightingEffect(Light2D lightToDeactivate)
    {
        DOTween.To(() => lightToDeactivate.intensity, x => lightToDeactivate.intensity = x, 0, 1);
        yield return new WaitForSeconds(3);
        lightToDeactivate.gameObject.SetActive(false);
    }

    IEnumerator ActivateLightingEffects(Light2D lightingToActivate, float lerpInSeconds)
    {
        if (dimOffLightingEffectCoroutine!=null) StopCoroutine(dimOffLightingEffectCoroutine);
        // Polish it later
        while (true)
        {
            yield return new WaitForSeconds(1);
            // Tween a float called myFloat to 52 in 1 second
            float rand = Random.Range(intensityMinMaxValues.x, intensityMinMaxValues.y);
            DOTween.To(() => lightingToActivate.intensity, x => lightingToActivate.intensity = x, rand, 1);
            rand = Random.Range(innerRadiusMinMaxValues.x, innerRadiusMinMaxValues.y);
            DOTween.To(() => lightingToActivate.pointLightInnerRadius, y => lightingToActivate.pointLightInnerRadius = y, rand, 1);
            rand = Random.Range(outerRadiusMinMaxValues.x, outerRadiusMinMaxValues.y);
            DOTween.To(() => lightingToActivate.pointLightOuterRadius, z => lightingToActivate.pointLightOuterRadius = z, rand, 1);
        }
    }
}
