using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongatongSpawnSetter : SpawnPositionSetter
{
    public override Vector3 SetSpawnPosition()
    {
        currentSpawnPosition = new Vector3(1, 1, 1);
        return currentSpawnPosition;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
  

}
