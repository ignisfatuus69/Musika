using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool isReadyToLoadScene = true;
    int currentActiveSceneIndex = 0;
    int nextSceneIndex = 0;
    private void Start()
    {
        SceneManager.sceneLoaded += enableSceneLoading;
        SceneManager.sceneUnloaded += disableSceneLoading;
        SingletonManager.instance.RegisterSingleton<SceneLoader>(this);
        SceneManager.sceneLoaded += SetNewActiveScene;
    }

    public void enableSceneLoading(Scene scene, LoadSceneMode mode)
    {
        isReadyToLoadScene = true;
    }
    public void disableSceneLoading(Scene scene)
    {
        isReadyToLoadScene = false;
    }
    public void LoadSceneAdditive(int sceneIndex)
    {
        if (!isReadyToLoadScene) return;
        if (sceneIndex == nextSceneIndex) return;
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        currentActiveSceneIndex = sceneIndex;
        nextSceneIndex = sceneIndex;
    }

    public void LoadSceneEntirely(int sceneIndex)
    {
        if (!isReadyToLoadScene) return;
        if (sceneIndex == nextSceneIndex) return;

        // You unload the current active scene
        Debug.Log("not working?");
        currentActiveSceneIndex = sceneIndex;
        nextSceneIndex = sceneIndex;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        // and then u load the new scene
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }
    public void RestartScene()
    {
        if (!isReadyToLoadScene) return;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Additive);
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isReadyToLoadScene) return;
            int index = SingletonManager.instance.GetSingleton<PlayerData>().index += 1;
            LoadSceneAdditive(index);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isReadyToLoadScene) return;
            LoadSceneEntirely(2);
        }
    }

    private void SetNewActiveScene(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(currentActiveSceneIndex);
        StartCoroutine(SetActiveScene(currentActiveSceneIndex));
    }
    IEnumerator SetActiveScene(int sceneIndex)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }
}
