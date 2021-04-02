using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Test : MonoBehaviour
{
    private void Awake()
    {
      //  SingletonManager.RegisterSingleton<Test>(this);
    }

    private void Start()
    {
        SingletonManager.RegisterSingleton<Test>(this);
    }
    // Start is called before the first frame update
    public void PrintPare()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(1);
        }
        Debug.Log("print mo nga pare");
    }
}
