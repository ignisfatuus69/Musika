using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Timeline.Midi;
[CreateAssetMenu(fileName = "SongData", menuName = "ScriptableObjects/SongData", order = 1)]
public class SongData : ScriptableObject
{
    [SerializeField] private string songId;
    public string GetSongId => songId;
    public List<int> beatNoteIndexes { get; set; }
    public List<double> beatTimeStamps { get; set; }
    public List<MidiNoteFilter> notes { get; set; }
    public Dictionary<int, MidiNoteFilter> notesDictionary { get; set; } = new Dictionary<int, MidiNoteFilter>();

}
