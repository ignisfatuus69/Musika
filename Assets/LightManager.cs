using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.LWRP;
public class LightManager : MonoBehaviour
{
    [SerializeField] private float startingGlobalLighting;
    [SerializeField] private float startingGabbingLighting;
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D globalLighting;
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D gabbangLighting;
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D[] lightingEffects; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetStartingSceneLighting());
    }


    IEnumerator SetStartingSceneLighting()
    {
        DOTween.To(() => globalLighting.intensity, x => globalLighting.intensity = x, startingGlobalLighting, 3);
        yield return new WaitForSeconds(4);
        DOTween.To(() => gabbangLighting.intensity, x => gabbangLighting.intensity = x, startingGabbingLighting, 2);
    }

    public void PutLightsOut()
    {
        StartCoroutine(LightsOut());
    }
    IEnumerator LightsOut()
    {
        DOTween.To(() => gabbangLighting.intensity, x => gabbangLighting.intensity = x, 0.05f, 1);
        yield return new WaitForSeconds(1);
        DOTween.To(() => globalLighting.intensity, x => globalLighting.intensity = x, 0.05f, 1);
    }
}
