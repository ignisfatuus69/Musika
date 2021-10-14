using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ResourceText : MonoBehaviour
{
    [SerializeField] private Resource resourceObj;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string textBeforeValue;
    [SerializeField] private string textAfterValue;
    // Start is called before the first frame update
    void Start()
    {
        resourceObj.EVT_OnValueModified.AddListener(UpdateText);
        UpdateText();
    }

    void UpdateText()
    {
        textComponent.text = textBeforeValue + resourceObj.currentValue + textAfterValue;
    }
}
