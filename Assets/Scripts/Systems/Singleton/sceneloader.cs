using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex = 0;
    private void Start()
    {
        SingletonManager.instance.RegisterSingleton<SceneLoader>(this);
    }
    public void LoadSceneAdditive(int sceneIndex)
    {
        if (sceneIndex == currentSceneIndex) return;
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        StartCoroutine(SetActiveScene(sceneIndex));
        currentSceneIndex = sceneIndex;
    }

    public void LoadSceneEntirely(int sceneIndex)
    {
        if (sceneIndex == currentSceneIndex) return;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        StartCoroutine(SetActiveScene(sceneIndex));
        currentSceneIndex = sceneIndex;
    }

    public void RestartScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Additive);
        StartCoroutine(SetActiveScene(SceneManager.GetActiveScene().buildIndex));
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int index = SingletonManager.instance.GetSingleton<PlayerData>().index += 1;
            LoadSceneAdditive(index);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            LoadSceneEntirely(2);
        }
    }


    IEnumerator SetActiveScene(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }
}
