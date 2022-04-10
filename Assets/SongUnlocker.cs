using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SongUnlocker : MonoBehaviour
{
    private int tongatongSongScoresCount= 0;
    private int kolitongSongScoresCount= 0;
    private int gabbangSongScoresCount = 0;


    [SerializeField] private GameObject[] tongatongLockedButtons;
    [SerializeField] private GameObject[] kolitongLockedButtons;
    [SerializeField] private GameObject[] gabbangLockedButtons;

    [SerializeField] private GameObject[] tongatongPlayButtons;
    [SerializeField] private GameObject[] kolitongPlayButtons;
    [SerializeField] private GameObject[] gabbangPlayButtons;
    private List<SongScore> songScoreList = new List<SongScore>();
    // Start is called before the first frame update
    void Start()
    {
        //check if this just works for start and dont need this lol
      //  SceneManager.sceneLoaded += CheckForUnlockableSongs;
        CheckForUnlockableSongs();
    }

    private void CheckForUnlockableSongs()
    {
        //Think about polishing to make a cutscene for the unlocking song later
        this.songScoreList = SingletonManager.instance.GetSingleton<PlayerData>().songScoresList;
        for (int i = 0; i < songScoreList.Count; i++)
        {
            if (songScoreList[i].instrumentType == Instrument.Tongatong) tongatongSongScoresCount += 1;
            if (songScoreList[i].instrumentType == Instrument.Kolitong) kolitongSongScoresCount += 1;
            if (songScoreList[i].instrumentType == Instrument.Gabbang) gabbangSongScoresCount += 1;
        }

        Debug.Log(tongatongSongScoresCount);
        for (int i = 0; i < tongatongSongScoresCount; i++)
        {
            tongatongLockedButtons[i].SetActive(false);
            tongatongPlayButtons[i].SetActive(true);
            Debug.Log($"unlocked next song pare");
        }

        for (int i = 0; i < kolitongSongScoresCount; i++)
        {
            kolitongLockedButtons[i].SetActive(false);
            kolitongPlayButtons[i].SetActive(true);
        }

        for (int i = 0; i < gabbangSongScoresCount; i++)
        {
            gabbangLockedButtons[i].SetActive(false);
            gabbangPlayButtons[i].SetActive(true);
        }
    }
}
