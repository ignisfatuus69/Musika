using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class SetObjectActiveOnTime : MonoBehaviour
{
    public bool isUsingDirector;
    [SerializeField] private GameObject gameObjectToEnable;
    [SerializeField] private PlayableDirector sceneDirector; 
    [SerializeField] private int[] timesToEnable;
    [SerializeField] private int[] timesToDisable;
    private int enablingIndex = 0;
    private int disablingIndex = 0;
    private float timer=0;
    private Coroutine SetObjectActiveCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        SetObjectActiveCoroutine = StartCoroutine(SetObjectsAcive());
        if(!isUsingDirector)
        {
            StartCoroutine(StartTimer());
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1);
        timer += 1;
    }

    IEnumerator SetObjectsAcive()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if (enablingIndex >= timesToEnable.Length)
            {
                gameObjectToEnable.SetActive(false);
                StopCoroutine(SetObjectActiveCoroutine);
            }


            if (!isUsingDirector)
            {
                if (timer >= timesToEnable[enablingIndex])
                {
                    gameObjectToEnable.SetActive(true);
                    enablingIndex += 1;
                }
                if (timer >= timesToDisable[disablingIndex])
                {
                    gameObjectToEnable.SetActive(false);
                    disablingIndex += 1;
                }
                yield return null;
            }

            else if (isUsingDirector)
            {
                if (sceneDirector.time >= timesToEnable[enablingIndex])
                {
                    gameObjectToEnable.SetActive(true);
                    enablingIndex += 1;
                }
                if (sceneDirector.time >= timesToDisable[disablingIndex])
                {
                    gameObjectToEnable.SetActive(false);
                    disablingIndex += 1;
                }
                yield return null;
            }
        }
    }
}
