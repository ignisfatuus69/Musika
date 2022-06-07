using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class DialogueSkipper : MonoBehaviour
{
    [SerializeField] private int[] timeSkipReferencesInSeconds;
    [SerializeField] private PlayableDirector cutsceneDirector;
    private int amountSkipped=0;

    public void SkipToNextPart()
    {
        if (amountSkipped >= timeSkipReferencesInSeconds.Length) return;
        StartCoroutine(Skip());
      
    }

    IEnumerator Skip()
    {
        cutsceneDirector.Pause();
        cutsceneDirector.time = timeSkipReferencesInSeconds[amountSkipped];
        cutsceneDirector.Play();
        yield return new WaitForSeconds(0.1f);
        cutsceneDirector.Pause();
        cutsceneDirector.Play();
        amountSkipped += 1;
    }
}
