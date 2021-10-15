using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScoreEffect : MonoBehaviour
{
    [SerializeField] private Resource scoreComponent;
    [SerializeField] private Transform scoreTextTransform; 
    // Start is called before the first frame update
    void Start()
    {
        scoreComponent.EVT_OnValueModified.AddListener(SlidingEffect);
    }

    void SlidingEffect()
    {

        scoreTextTransform.transform.DOShakePosition(0.25f, 5, 1, 90);
    }
}
