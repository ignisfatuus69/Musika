using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEffect : MonoBehaviour
{
    public OnDeactivate EVT_OnDeactivate;
    [SerializeField] private float despawnTime;

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DeactivateInSeconds());
    }
    IEnumerator DeactivateInSeconds()
    {
        yield return new WaitForSeconds(despawnTime);
        EVT_OnDeactivate.Invoke(this.gameObject);
    }
}
