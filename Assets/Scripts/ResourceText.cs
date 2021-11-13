using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ResourceText : MonoBehaviour
{
    public TextMeshProUGUI TextObj;
    public Resource ResourceObj;
    public string FirstHeaderText;
    public string SecondHeaderText;
    // Start is called before the first frame update
    void Start()
    {
        ResourceObj.EVT_OnValueInitialized.AddListener(UpdateText);
        ResourceObj.EVT_OnValueModified.AddListener(UpdateText);

    }

    void UpdateText()
    {
        TextObj.text = FirstHeaderText + ResourceObj.currentValue + SecondHeaderText;
    }
}
