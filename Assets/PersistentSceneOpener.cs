using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Playables;
public class PersistentSceneOpener : MonoBehaviour
{
    [SerializeField] private GameObject[] startupObjects;
    [SerializeField] private SceneLoader sceneLoaderObj;
    [SerializeField] private PlayableDirector introSceneDirector;
    [SerializeField] private VideoPlayer introVideoPlayer;
    [SerializeField] private GameObject[] openingObjects;

    int alternatingNumber = 0;
    private bool hasGameStarted = false;
    private bool canTransitionToMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTransitionCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTransitionToMenu) return;
        if (hasGameStarted) return;
        if (Input.anyKeyDown)
        {
            StartCoroutine(TransitionToNextScene());
            hasGameStarted = true;
            introVideoPlayer.SetDirectAudioMute(0, false);
            introSceneDirector.Pause();
            introSceneDirector.time = 4f;
            introSceneDirector.Play();
            return;
        }
        LoopDirector();
    }

    private void LoopDirector()
    {
        if(introSceneDirector.time>=1.9f)
        {
            introSceneDirector.Pause();
            introSceneDirector.time = 0;
            introSceneDirector.Play();
            alternatingNumber += 1;
            if (alternatingNumber % 2 == 0)
            {
                introVideoPlayer.SetDirectAudioMute(0, true);
                return;
            }
            else introVideoPlayer.SetDirectAudioMute(0, false);

        }
    }
    private IEnumerator StartTransitionCountdown()
    {
        yield return new WaitForSeconds(2);
        canTransitionToMenu = true;
    }

    private IEnumerator TransitionToNextScene()
    {

        yield return new WaitForSeconds(1f);
        EnableOpeningObjects();
        DisableStartupObjects();
        hasGameStarted = true;

    }

    private void DisableStartupObjects()
    {
        for (int i = 0; i < startupObjects.Length; i++)
        {
            startupObjects[i].SetActive(false);
        }
    }

    private void EnableOpeningObjects()
    {
        for (int i = 0; i < openingObjects.Length; i++)
        {
            openingObjects[i].SetActive(true);
        }
    }
}
