using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnValueReset : UnityEvent { };
[System.Serializable]
public class OnValueAdded : UnityEvent { };
[System.Serializable]
public class OnValueDeducted : UnityEvent { };
[System.Serializable]
public class OnValueModified : UnityEvent { };
public abstract class Resource : MonoBehaviour
{
    public OnValueAdded EVT_OnValueAdded;
    public OnValueDeducted EVT_OnValueDeducted;
    public OnValueReset EVT_OnValueReset;
    public OnValueModified EVT_OnValueModified;

    [SerializeField]private float minimumValue=0;
    [SerializeField]private float maximumValue=0;

    public float currentValue { get; set; }
    public bool hasCap = true;

    public float GetMinimumValue=>minimumValue;
    public float GetMaximumValue => maximumValue;
    private void Start()
    {
        currentValue = minimumValue;
    }

    private void CapValue()
    {
        if (!hasCap) return;
        Mathf.Clamp(currentValue, minimumValue, maximumValue);
    }

    protected void ResetValue()
    {
        currentValue = minimumValue;
        EVT_OnValueModified.Invoke();
        EVT_OnValueReset.Invoke();


    }
    protected virtual void OnValueModified()
    {
        CapValue();
        EVT_OnValueModified.Invoke();
    }

}
