using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotebookButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }

    public void UnloadScene(int sceneIndex)
    {
        SceneManager.UnloadSceneAsync(sceneIndex);
    }

    public void LoadSceneSingle(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
