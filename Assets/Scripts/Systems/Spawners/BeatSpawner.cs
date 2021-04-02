using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : ObjectPooler
{
    [SerializeField]private int[] singleIndexes;
    [SerializeField]private int[] doubledIndexes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spawn();
        }
    }
    protected override void SetPoolingConditions(GameObject obj)
    {
        Beat beatObj = obj.GetComponent<Beat>();
        beatObj.EVT_OnDeactivate.AddListener(Pool);
    }

}
