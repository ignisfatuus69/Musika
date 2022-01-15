using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonTab : MonoBehaviour
{
    [SerializeField]private GameObject selectedObj;
    [SerializeField]private GameObject previousTab;
    [SerializeField]private GameObject[] notebookTabs;
    [SerializeField]private GameObject[] notebookSections;
    public int sectionIndex { get; set; }
    public int tabIndex { get; set; }

    private void Start()
    {
        EnableSection(SingletonManager.instance.GetSingleton<PlayerData>().notebookData.enabledSectionIndex);
        EnlargeCurrentTab(SingletonManager.instance.GetSingleton<PlayerData>().notebookData.enlargedTabIndex);

    }
    public void EnableSection(int sectionIndex)
    {
        if (selectedObj != null) selectedObj.SetActive(false);
        selectedObj = notebookSections[sectionIndex];
        notebookSections[sectionIndex].SetActive(true);
        SingletonManager.instance.GetSingleton<PlayerData>().notebookData.enabledSectionIndex = sectionIndex;
    }

    public void EnlargeCurrentTab(int tabIndex)
    {
        if (previousTab!=null) previousTab.transform.DOScale(1.45f, 0.25f);
        notebookTabs[tabIndex].transform.DOScale(1.75f, 0.25f);
        previousTab = notebookTabs[tabIndex];
        SingletonManager.instance.GetSingleton<PlayerData>().notebookData.enlargedTabIndex = tabIndex;
    }

    public void UnlockSongButton()
    {

    }
}
