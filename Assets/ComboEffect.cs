using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class ComboEffect : MonoBehaviour
{
    [SerializeField] private float timeToScale;
    [SerializeField] private Combo comboComponent;
    [SerializeField] private Transform comboTextTransform;
    [SerializeField] private TextMeshProUGUI textMeshProComponent;

    // Start is called before the first frame update
    void Start()
    {
        comboComponent.EVT_OnValueModified.AddListener(AdjustSize);
        comboComponent.EVT_OnValueModified.AddListener(ShowAppearance);
    }

    void AdjustSize()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        comboTextTransform.transform.DOScale(1.25f, timeToScale);
     
    }

    void ShowAppearance()
    {
        if (comboComponent.currentValue <= 0) textMeshProComponent.enabled = false;
        if (comboComponent.currentValue > 0) textMeshProComponent.enabled = true;
    }
}
