using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Lifebar : MonoBehaviour
{
    [SerializeField] private Life lifeSystemObj;
    [SerializeField] private Image barImage;
    [SerializeField] private List<Color> colors = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        lifeSystemObj.EVT_OnValueModified.AddListener(AdjustBar);
        barImage.color = colors[0];
    }

    private void AdjustBar()
    {
        float value = lifeSystemObj.currentValue / lifeSystemObj.GetMaximumValue;
        barImage.DOFillAmount(value, 0.25f);
        ChangeColor(value);

    }

    private void ChangeColor(float value)
    {
        if (value > 0.70) barImage.color = colors[0];
        if (value <= 0.70 && value >= 0.30) barImage.color = colors[1];
        if (value < 0.30) barImage.color = colors[2];
    }
}
