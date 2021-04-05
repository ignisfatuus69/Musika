using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Timeline.Midi;
public class BeatIndexer : MonoBehaviour
{
    [SerializeField] private SongData songDataScriptableObject;
    [SerializeField] private int[] beatIndexes;

    [SerializeField] private MidiSignalReceiver midiSignalReceiverComponent;
    private MidiNoteFilter notes;
    private int indexedBeatsCount=0;

    private void Start()
    {
        if (midiSignalReceiverComponent != null)this.notes = midiSignalReceiverComponent.noteFilter;
    }

    public void AddIndex()
    {
        if (beatIndexes.Length <= 1)
        {
            Debug.Log("Added Index");
            indexedBeatsCount += 1;
            songDataScriptableObject.beatNoteIndexes.Add(this.beatIndexes[0]);
            return;
        }
        if (beatIndexes.Length > 1) EvaluateDoubleIndexes();
    }

    public void EvaluateDoubleIndexes()
    {
        //This solution only works if there's 2
        //Even Numbers
        Debug.Log("pre");
        if (indexedBeatsCount % 2 == 0)
        {
            Debug.Log("Added Index");
            songDataScriptableObject.beatNoteIndexes.Add(this.beatIndexes[0]);
            indexedBeatsCount += 1;
            return;
        }
        //Odd numbers
        else if (indexedBeatsCount % 2 == 1)
        {
            Debug.Log("Added Index");
            songDataScriptableObject.beatNoteIndexes.Add(this.beatIndexes[1]);
            indexedBeatsCount += 1;
            return;
        }
    }

    public void AddNotes()
    {
        Debug.Log("Added Note");
        songDataScriptableObject.notes.Add(this.notes);
        
    }
}
