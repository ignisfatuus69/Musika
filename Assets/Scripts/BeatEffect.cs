using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEffect : MonoBehaviour
{
    public OnDeactivate EVT_OnDeactivate;
    public BeatEffectSpawner beatEffectSpawnerReference;
    [SerializeField] private GameObject[] particles;
    [SerializeField] private float despawnTime;
    


    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DeactivateInSeconds());
    }
    IEnumerator DeactivateInSeconds()
    {
        yield return new WaitForSeconds(0.05f);
        ActivateParticles();
        yield return new WaitForSeconds(despawnTime);
        EVT_OnDeactivate.Invoke(this.gameObject);
        DisableAllParticles();
    }

    public void DisableAllParticles()
    {
        for (int i = 1; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
    }
    public void ActivateParticles()
    {
        if (beatEffectSpawnerReference.currentBeatState == BeatState.Okay) particles[1].SetActive(true);
        else if (beatEffectSpawnerReference.currentBeatState == BeatState.Perfect) particles[2].SetActive(true);
    }
}
