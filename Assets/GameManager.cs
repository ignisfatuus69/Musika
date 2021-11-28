using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Playables;
public enum SongDifficulty
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}
public class GameManager : MonoBehaviour
{
    [SerializeField] private SongData songData;
    [SerializeField] private BeatSpawner beatSpawnerObj;
    [SerializeField] private PlayableDirector beatDirector;
    [SerializeField] Life LifeCounterObj;
    [SerializeField] private SongDifficulty songDifficulty;
    [SerializeField] private LightManager lightManagerObj;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Animator summaryUIAnimator;
    [SerializeField] private Score scoreTracker;

    private SongScore currentSongScoreData = new SongScore();

    private bool isPaused = false;
    private bool isDone = false;

    public SongDifficulty GetSongDifficulty => this.songDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        LifeCounterObj.EVT_OnValueDeducted.AddListener(SetGameOver);
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(FinishGame);
    }

    private void FinishGame(Beat beat)
    {
        if (isDone) return;
        if (beatSpawnerObj.totalPooledCount >= songData.beatNoteIndexes.Count) 
        {
            StartCoroutine(FinalizePlayerScore());
        }
    }

    private void StoreSongScoreData()
    {
        currentSongScoreData.missAmount = (int)scoreTracker.missCounter.currentValue;
        currentSongScoreData.goodAmount = (int)scoreTracker.goodCounter.currentValue;
        currentSongScoreData.perfectAmount = (int)scoreTracker.perfectCounter.currentValue;
        currentSongScoreData.totalScore = (int)scoreTracker.currentValue;
        currentSongScoreData.songRanking = scoreTracker.songGrade;

        // if song score data does not exist
        if (!SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary.ContainsKey(this.songData.name))
        {
            SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary.Add(this.songData.name, this.currentSongScoreData);
            SingletonManager.instance.GetSingleton<PlayerData>().songScoreListTest.Add(this.currentSongScoreData);

        }

        //replace song score data if the score is currently higher than the previous
        else if (SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary.ContainsKey(this.songData.name))
        {
            if (currentSongScoreData.totalScore> SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary[this.songData.name].totalScore)
            {
                SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary.Remove(this.songData.name);
                SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary.Add(this.songData.name, this.currentSongScoreData);
            }
        }
    }
    private void SetGameOver()
    {
        if (LifeCounterObj.currentValue > LifeCounterObj.GetMinimumValue) return;
        StartCoroutine(DisableSpawner());
        FallBeats();
        lightManagerObj.PutLightsOut();
    }
    
    private IEnumerator DisableSpawner()
    {
        if (isPaused) yield return null;
        beatDirector.Stop();
        yield return new WaitForSeconds(0.1f);
        isPaused = true;
        gameOverUI.SetActive(true);
    }

    private void FallBeats()
    {
        if (isPaused) return;
        List<GameObject> spawnedBeats = beatSpawnerObj.currentSpawnedObjects;
        
        for (int i = 0; i < spawnedBeats.Count; i++)
        {
            spawnedBeats[i].transform.DOMoveY(-15, 30);
        }
    }

    IEnumerator FinalizePlayerScore()
    {
        yield return new WaitForEndOfFrame();
        summaryUIAnimator.SetBool("isDone", true);
        StoreSongScoreData();
        isDone = true;

        Debug.Log(SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary[this.songData.name].missAmount);
        Debug.Log(SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary[this.songData.name].goodAmount);
        Debug.Log(SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary[this.songData.name].perfectAmount);
        Debug.Log(SingletonManager.instance.GetSingleton<PlayerData>().songScoreDictionary[this.songData.name].totalScore);

        Time.timeScale = 0;
    }


}
