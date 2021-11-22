using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    public int index = 0;
    public int randomNumber = 69999;
    // Start is called before the first frame update
    void Start()
    {
        SingletonManager.instance.RegisterSingleton<PlayerData>(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            index += 1;
            Debug.Log(" i like poop");
            Debug.Log(SingletonManager.instance.GetInstancesCount());
            SceneManager.LoadSceneAsync(index,LoadSceneMode.Additive);
        }
    }
}
