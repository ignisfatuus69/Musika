using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolitongManager : MonoBehaviour
{
    public SongData songData;
    public Direction[] noteDirections;

    public Direction currentBeatDirection { get; private set; } = Direction.Left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
