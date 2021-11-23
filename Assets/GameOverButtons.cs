using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    public void RestartLevel()
    {
        SingletonManager.instance.GetSingleton<SceneLoader>().RestartScene();
    }

    public void ReturnToNotebookMenu(int sceneIndex)
    {
        SingletonManager.instance.GetSingleton<SceneLoader>().LoadSceneEntirely(sceneIndex);
    }
}
