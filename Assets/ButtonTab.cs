using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonTab : MonoBehaviour
{
    [SerializeField]private GameObject selectedObj;
    [SerializeField] private GameObject previousTab;
    public void EnableSection(GameObject obj)
    {
        if (selectedObj != null) selectedObj.SetActive(false);
        obj.SetActive(true);
        selectedObj = obj;
    }

    public void EnlargeCurrentTab(GameObject obj)
    {
        if (previousTab!=null) previousTab.transform.DOScale(1.45f, 0.25f);
        obj.transform.DOScale(1.75f, 0.25f);
        previousTab = obj;
    }
}
