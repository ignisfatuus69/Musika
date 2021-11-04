using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class OnButtonPress : UnityEvent { };

public class ButtonObject : MonoBehaviour,IInteractable
{
    public OnButtonPress EVT_OnButtonPress;
    public void OnTapAction()
    {
        EVT_OnButtonPress.Invoke();
    }
    
    public void Test()
    {
        Debug.Log("yeet");
    }
}
