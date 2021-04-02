using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPositionSetter:MonoBehaviour
{
    public Vector3 currentSpawnPosition { get; protected set; } = new Vector3(0, 0, 0);
    public abstract Vector3 SetSpawnPosition();

}
