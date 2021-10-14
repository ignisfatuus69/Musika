using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
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
        Debug.Log("hoyhotyhoy");

    }

    public void Heyman(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(1);
    }


}
