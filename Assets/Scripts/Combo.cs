using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combo : Resource
{
    [SerializeField] private BeatSpawner beatSpawnerObj;
    // Start is called before the first frame update
    void Start()
    {
        beatSpawnerObj.EVT_OnBeatPooled.AddListener(ModifyComboCount);
    }

    private void ModifyComboCount(Beat beatObj)
    {
        if (beatObj.beatState == BeatState.Miss)
        {
            currentValue = 0;
            OnValueModified();
            EVT_OnValueReset.Invoke();
            return;
        }

        //If it's not a miss then add
        currentValue += 1;
        OnValueModified();
        EVT_OnValueAdded.Invoke();
    }
}
