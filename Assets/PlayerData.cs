using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SongScore
{
    public int missAmount;
    public int goodAmount;
    public int perfectAmount;
    public int totalScore;
}
public class PlayerData : MonoBehaviour
{
    public int index = 0;
    public int randomNumber = 69999;
    public Dictionary<string,SongScore> songScoreDictionary = new Dictionary<string, SongScore>();

    // Start is called before the first frame update
    void Start()
    {
        SingletonManager.instance.RegisterSingleton<PlayerData>(this);
    }

}
