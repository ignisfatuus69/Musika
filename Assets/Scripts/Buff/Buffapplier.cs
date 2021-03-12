using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffapplier : MonoBehaviour
{
    public BuffManager buffReceiver;
    public Buff poisonDebuff;
    public Buff strengthenBuff;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Buff newStrengthBuff = Instantiate(strengthenBuff,buffReceiver.transform);
            buffReceiver.AddBuff(newStrengthBuff);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Buff newPoisonDebuff = Instantiate(poisonDebuff, buffReceiver.transform);
            buffReceiver.AddBuff(poisonDebuff);
        }
    }
}
