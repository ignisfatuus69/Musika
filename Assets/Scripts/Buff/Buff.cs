using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnBuffTimedUp : UnityEvent<Buff> { };

public abstract class Buff : MonoBehaviour
{
    public OnBuffTimedUp EVT_OnBuffTimedUp = new OnBuffTimedUp { };

    [SerializeField] public string id;
    [SerializeField] public bool isStackedOnIntensity;
    [SerializeField] public bool isStackedOnDuration;
    [SerializeField] public bool isNotStacked;
    [SerializeField] public bool isActivated;
    [SerializeField] public float duration;
    [SerializeField] public float buffValue;
    [SerializeField] public int maxStackAmount;

    protected abstract void Effect();

    public IEnumerator Activate()
    {
        if (!isActivated) yield return null;

        this.Effect();
        yield return new WaitForSeconds(duration);
        EVT_OnBuffTimedUp.Invoke(this);
        gameObject.SetActive(false);
    }

}
