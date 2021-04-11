using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnValueModified : UnityEvent { };
public abstract class Resource : MonoBehaviour
{
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

    protected virtual void OnValueModified()
    {
        CapValue();
        EVT_OnValueModified.Invoke();
    }

}
