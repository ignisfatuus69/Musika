using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDebuff : Buff
{
    protected override void Effect()
    {
        Debug.Log("Poison");
    }
}
