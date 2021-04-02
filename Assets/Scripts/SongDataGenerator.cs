using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.IO;
using UnityEngine.Events;
public class SongDataGenerator : MonoBehaviour
{
    // song data to generate
    [SerializeField]private SongData songDataScriptableObject;
    [SerializeField]private PlayableDirector songDirectorObj;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Generating song data for: " + songDataScriptableObject.GetSongId);
        ClearSongData();
    }

    public void SetSongData()
    {
        AddTimeStampsToSongData();
        // If time is up, Make JSON
        if (songDirectorObj.time>= songDirectorObj.duration)
        {
            Debug.Log("Finished Generating Song Data");
            Debug.Log("Beat Indexes Count:" + songDataScriptableObject.beatNoteIndexes.Count);
            Debug.Log("Beat TimeStamps Count:" + songDataScriptableObject.beatTimeStamps.Count);
        }
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
        if (songDataScriptableObject.notesDictionary.Count > 0) songDataScriptableObject.notesDictionary.Clear();
    }
}
