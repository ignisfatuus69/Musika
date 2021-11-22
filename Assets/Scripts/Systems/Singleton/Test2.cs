using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test2 : MonoBehaviour
{
    public int indexer = 69;
    // Start is called before the first frame update
    void Start()
    {
        indexer = SingletonManager.instance.GetSingleton<PlayerData>().randomNumber;
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void testtest(InputAction.CallbackContext ctx)
    {
     
    }
}
