using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthenBuff : Buff
{
    protected override void Effect()
    {
        StartCoroutine(StrengthEverySecond());
    }

    IEnumerator StrengthEverySecond()
    {
        while (this.gameObject.activeSelf)
        {
            Debug.Log("Strengthens");
            yield return new WaitForSeconds(1);
            
        }
    }
}
