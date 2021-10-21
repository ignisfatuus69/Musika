using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolitongBeatSpawner : BeatSpawner
{
    [SerializeField] private Direction[] noteDirections;
    protected override void Start()
    {
        base.Start();
        EVT_OnBeatSpawned.AddListener(SetBeatDirection);
    }
    private void SetBeatDirection(Beat beatObj)
    {
        if (beatObj.GetComponent<KolitongBeat>() == null) return;
        KolitongBeat kolitongBeat = beatObj.GetComponent<KolitongBeat>();

        int randomNumber = Random.Range(0,2);
        if (randomNumber == 0) kolitongBeat.beatDirection = Direction.Left;
        if (randomNumber == 1) kolitongBeat.beatDirection = Direction.Right;
        kolitongBeat.SetOrderLayer();
        kolitongBeat.FlipArrow();
    }

    
}
