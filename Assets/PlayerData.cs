using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct SongScore
{
    public int missAmount;
    public int goodAmount;
    public int perfectAmount;
    public int totalScore;
    public SongGrade songRanking;
}

[System.Serializable]
public struct NotebookData
{
    public int enabledSectionIndex;
    public int enlargedTabIndex;
}

public class PlayerData : MonoBehaviour
{
    public int index = 0;
    public int randomNumber = 69999;
    public Dictionary<string,SongScore> songScoreDictionary = new Dictionary<string, SongScore>();
    public List<SongScore> songScoreListTest = new List<SongScore>();
    public NotebookData notebookData;
    // Start is called before the first frame update
    void Start()
    {
        SingletonManager.instance.RegisterSingleton<PlayerData>(this);
    }

}
