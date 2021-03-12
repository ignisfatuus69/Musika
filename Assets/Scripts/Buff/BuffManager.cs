using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// Handles tracking and stacking of buffs
// Removes and applies buffs
public class BuffManager : MonoBehaviour
{
    public List<Buff> currentBuffs { get; private set; } = new List<Buff>();
    public Dictionary<string, int> currentBuffsInventory { get; private set; } = new Dictionary<string, int>();

    //Add buff to the list and inventory
    public void AddBuff(Buff buffReference)
    {
        // Do not add non stackable buffs if it's currently added already
        if (currentBuffsInventory.ContainsKey(buffReference.id) 
            && buffReference.isNotStacked) return;

        //Add to list
        currentBuffs.Add(buffReference);

        //Only keep 

        buffReference.EVT_OnBuffTimedUp.AddListener(ReduceStackAmount);
        //Set stack amount to stackable buffs
        this.SetStackAmount(buffReference);

        //Activate Buff
        ActivateBuff(buffReference);
    }

    //Sets the stack amount to the buff inventory ,everytime something is added 
    private void SetStackAmount(Buff buffReference)
    {
        // If there's no buff yet, set stack count to 0
        if (!currentBuffsInventory.ContainsKey(buffReference.id))
        {
            currentBuffsInventory.Add(buffReference.id, 1);
            return;
        }
        if (buffReference.isNotStacked) return;
        // If there is, add the value by 1
        currentBuffsInventory[buffReference.id] += 1; 
    }

    private void ActivateBuff(Buff buffReference)
    {
        //Only activate if it's the first buff
        //if (currentBuffsInventory[buffReference.id] <= 1)
        //{
        //    buffReference.isActivated = true;
        //    StartCoroutine(buffReference.Activate());
        //}
        //else return;
    }

    private  void ActivateNextStack(Buff buffReference)
    {
        //Debug.Log(currentBuffs.Count);

        //currentBuffs[0].isActivated = true;

        //for (int i = 0; i < currentBuffs.Count; i++)
        //{
        //    if (buffReference.id == currentBuffs[i].id)
        //    {
        //        buffReference.isActivated = true;
        //    }
        //}
        ////Find the next buff and activate it
        ////for (int i = 0; i < currentBuffs.Count; i++)
        ////{
        ////    if (currentId == currentBuffs[i].id && buffReference.gameObject.activeSelf)
        ////    {
        ////        buffReference.isActivated = true;
        ////        StartCoroutine(buffReference.Activate());
        ////        return;
        ////    }
        ////}
    }
    private void ReduceStackAmount(Buff buffReference)
    {
      
        currentBuffs.Remove(buffReference);

        if (currentBuffsInventory[buffReference.id] == 0) return;
        currentBuffsInventory[buffReference.id] -= 1;

        Debug.Log(buffReference.id + currentBuffsInventory[buffReference.id]);

        //Remove from dictionary if it's already 0
        //ClearInactiveBuffs();

    }

    private void RemoveBuffFromListAndInventory(Buff buffReference)
    {
        if (currentBuffsInventory[buffReference.id]<=0)
        {
            currentBuffs.Remove(buffReference);
            currentBuffsInventory.Remove(buffReference.id);
        }
    }

    private void ClearInactiveBuffs()
    {
        foreach (KeyValuePair<string, int> Buff in currentBuffsInventory)
        {
            if (Buff.Value == 0) currentBuffsInventory.Remove(Buff.Key);
        }
    }
}
