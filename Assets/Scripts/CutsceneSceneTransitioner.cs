using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class CutsceneSceneTransitioner : MonoBehaviour
{
    [SerializeField] private bool willTransitionAfterCutscene;
    [SerializeField] private SceneLoader sceneLoaderObj;
    [SerializeField] private PlayableDirector sceneDirector;
    [SerializeField] private float timeToTransition;

    private float timer;

    private void Start()
    {
        StartCoroutine(TransitionToNextScene());
    }
    IEnumerator TransitionToNextScene()
    {
        while(true)
        {
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
            if (timer >= timeToTransition)
            {
                if(timer>sceneDirector.duration)
                {
                    sceneLoaderObj.LoadSceneAdditive(SceneManager.GetActiveScene().buildIndex + 1);
                }
                sceneDirector.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
          
        }
    }
}
