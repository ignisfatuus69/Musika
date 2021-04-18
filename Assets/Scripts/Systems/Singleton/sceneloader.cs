using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public Image preImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        }
    }

    public void LoadSceneAdditive(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }
}
