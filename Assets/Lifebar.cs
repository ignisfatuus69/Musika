using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Lifebar : MonoBehaviour
{
    [SerializeField] private Life lifeSystemObj;
    [SerializeField] private Image barImage;
    // Start is called before the first frame update
    void Start()
    {
        lifeSystemObj.EVT_OnValueModified.AddListener(AdjustBar);    
    }

    private void AdjustBar()
    {

        barImage.DOFillAmount(lifeSystemObj.currentValue / lifeSystemObj.GetMaximumValue, 0.25f);
    }
}
