using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PersistentSceneOpener : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoaderObj;
    [SerializeField] private int mainMenuSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneLoaderObj.LoadSceneAdditive(mainMenuSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

        }
    }
}
