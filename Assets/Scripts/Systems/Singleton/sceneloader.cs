using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public bool isReadyToLoadScene = true;

    int currentSceneIndex = 0;
    private void Start()
    {
        SceneManager.sceneLoaded += enableSceneLoading;
        SceneManager.sceneUnloaded += disableSceneLoading;
        SingletonManager.instance.RegisterSingleton<SceneLoader>(this);
    }

    public void enableSceneLoading(Scene scene,LoadSceneMode mode)
    {
        isReadyToLoadScene = true;
    }
    public void disableSceneLoading(Scene scene)
    {
        isReadyToLoadScene = false;
    }
    public void LoadSceneAdditive(int sceneIndex)
    {
        if (!isReadyToLoadScene)return;
        if (sceneIndex == currentSceneIndex) return;
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        StartCoroutine(SetActiveScene(sceneIndex));
        currentSceneIndex = sceneIndex;
    }

    public void LoadSceneEntirely(int sceneIndex)
    {
        if (!isReadyToLoadScene) return;
        if (sceneIndex == currentSceneIndex) return;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        StartCoroutine(SetActiveScene(sceneIndex));
        currentSceneIndex = sceneIndex;
    }

    public void RestartScene()
    {
        if (!isReadyToLoadScene) return;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Additive);
        StartCoroutine(SetActiveScene(SceneManager.GetActiveScene().buildIndex));
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isReadyToLoadScene) return;
            int index = SingletonManager.instance.GetSingleton<PlayerData>().index += 1;
            LoadSceneAdditive(index);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            if (!isReadyToLoadScene) return;
            LoadSceneEntirely(2);
        }
    }


    IEnumerator SetActiveScene(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }
}
