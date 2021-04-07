using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Timeline.Midi;
using System.IO;

[CreateAssetMenu(fileName = "SongData", menuName = "ScriptableObjects/SongData", order = 1)]
public class SongData : ScriptableObject
{

    [SerializeField] private string songId;
    [SerializeField] private double offsetBeatTime;
    [SerializeField] private AudioClip songAudioClip;
    public bool isFilled=false;
    public string GetSongId => songId;
    public double GetOffsetBeatTime => offsetBeatTime;
    public AudioClip GetSongAudioClip => songAudioClip;
    public List<int> beatNoteIndexes;
    public List<double> beatTimeStamps;
    public List<MidiNoteFilter> notes;
   public Dictionary<int, MidiNoteFilter> notesDictionary { get; set; } = new Dictionary<int, MidiNoteFilter>();

    private void GetDataFromJson()
    {
        // If scriptable object has complete data don't get from JSON anymore
        if (isFilled) return;
        
        if (File.ReadAllText(Application.dataPath + "/" + songId + ".json")==null)
        {
            Debug.LogError("JSON does not exist");
            return;
        }

        string songDataString = File.ReadAllText(Application.dataPath + "/" + songId + ".json");
        SongDataClass newSongDataclass = JsonUtility.FromJson<SongDataClass>(songDataString);

        this.beatNoteIndexes = newSongDataclass.beatNoteIndexes;
        this.beatTimeStamps = newSongDataclass.beatTimeStamps;
        this.notes = newSongDataclass.notes;

        Debug.Log("Transferred JSON Data to Scriptable Object");
    }
    private void Awake()
    {
        GetDataFromJson();
    }

}
