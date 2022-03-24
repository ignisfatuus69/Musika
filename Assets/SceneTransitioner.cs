using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitioner : MonoBehaviour
{
    public void LoadSceneSingle(int sceneIndex)
    {
        SingletonManager.instance.GetSingleton<SceneLoader>().LoadSceneEntirely(sceneIndex);
    }
}
