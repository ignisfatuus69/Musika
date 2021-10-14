using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void testtest(InputAction.CallbackContext ctx)
    {
        SingletonManager.GetSingleton<Test>().PrintPare();
     
    }
}
