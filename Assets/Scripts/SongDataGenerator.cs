using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.IO;
using UnityEngine.Events;
using Klak.Timeline.Midi;

[System.Serializable]
public class SongDataClass
{
    public string songId;
    public List<int> beatNoteIndexes = new List<int>();
    public List<double> beatTimeStamps = new List<double>();
    public List<MidiNoteFilter> notes = new List<MidiNoteFilter>();
}

public class SongDataGenerator : MonoBehaviour
{
    // song data to generate
    [SerializeField]private SongData songDataScriptableObject;
    [SerializeField]private PlayableDirector songDirectorObj;

    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Generating song data for: " + songDataScriptableObject.GetSongId);
        ClearSongData();
    }

    public void SetSongData()
    {

        if (songDataScriptableObject.isFilled) return;
        AddTimeStampsToSongData();
        // If time is up, Make JSON
    }
    public void AddTimeStampsToSongData()
    {
        Debug.Log("Added Timestamp");
        songDataScriptableObject.beatTimeStamps.Add(songDirectorObj.time);
    }

    
    public void ClearSongData()
    {
        if (songDataScriptableObject.beatTimeStamps.Count > 0) songDataScriptableObject.beatTimeStamps.Clear();
        if (songDataScriptableObject.beatNoteIndexes.Count > 0) songDataScriptableObject.beatNoteIndexes.Clear();
        if (songDataScriptableObject.notes.Count > 0) songDataScriptableObject.notes.Clear();
    }

    private void CreateJSON()
    {
        SongDataClass songDataToSerialize = new SongDataClass();

        songDataToSerialize.songId = songDataScriptableObject.GetSongId;
        songDataToSerialize.beatNoteIndexes = (songDataScriptableObject.beatNoteIndexes);
        songDataToSerialize.beatTimeStamps = (songDataScriptableObject.beatTimeStamps);
        songDataToSerialize.notes = (songDataScriptableObject.notes);
        
        string json = JsonUtility.ToJson(songDataToSerialize);

        File.WriteAllText(Application.dataPath + "/" + songDataScriptableObject.GetSongId + ".json", json);
        Debug.Log("Created:" + songDataScriptableObject.GetSongId + "JSON");
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (songDataScriptableObject.isFilled) return;
        if (this.currentTime >= songDataScriptableObject.GetSongAudioClip.length)
        {
            Debug.Log("Finished Generating Song Data");
            Debug.Log("Beat Indexes Count:" + songDataScriptableObject.beatNoteIndexes.Count);
            Debug.Log("Beat TimeStamps Count:" + songDataScriptableObject.beatTimeStamps.Count);
            songDataScriptableObject.isFilled = true;
            CreateJSON();
        }
    }




}
