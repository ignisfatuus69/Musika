using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public enum SongDifficulty
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}
public class GameManager : MonoBehaviour
{
    [SerializeField] private BeatSpawner beatSpawnerObj;
    [SerializeField] private GameObject beatDirector;
    [SerializeField] Life LifeCounterObj;
    [SerializeField] private SongDifficulty songDifficulty;
    private bool isPaused = false;


    public SongDifficulty GetSongDifficulty => this.songDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        LifeCounterObj.EVT_OnValueDeducted.AddListener(SetGameOver);
    }


    private void SetGameOver()
    {
        if (LifeCounterObj.currentValue > LifeCounterObj.GetMinimumValue) return;
        FallBeats();
        StartCoroutine(DisableSpawner());
        
    }
    
    private IEnumerator DisableSpawner()
    {
        if (isPaused) yield return null;
        yield return new WaitForSeconds(2f);
        beatDirector.SetActive(false);
        isPaused = true;
        Debug.Log("hey");
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


}
