using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum SongDifficulty
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}
public class GameManager : MonoBehaviour
{
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
        if (LifeCounterObj.currentValue <= LifeCounterObj.GetMinimumValue) Debug.Log("Game Over Man");
    }
}
