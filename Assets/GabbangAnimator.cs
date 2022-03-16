using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GabbangAnimator : MonoBehaviour
{
    [SerializeField] private InputController inputControllerObj;
    [SerializeField] private Animator animatorComponent;
    // Start is called before the first frame update
    void Start()
    {
        inputControllerObj.EVT_OnStartTouch.AddListener(ActivateAnimation);
    }

    public void ActivateAnimation(Vector2 position, float time)
    {
        Debug.Log("hi");
    }

}
