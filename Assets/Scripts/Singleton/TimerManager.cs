using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerManager : MonoBehaviour
{
    public float CurTimer;
    private void Start()
    {
        SingletonManager.RegisterSingleton<TimerManager>(this);
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

    public void StopTimer()
    {
        Debug.Log("bruh");
    }

    private void OnComplete()
    {
        Debug.Log("bruh");
    }
}
