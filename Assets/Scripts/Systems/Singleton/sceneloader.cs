using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{

    public void LoadSceneAdditive(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }

    public void LoadSceneEntirely(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
