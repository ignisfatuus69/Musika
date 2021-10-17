using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongatongBeat : Beat,IInteractable
{
    public void Interact()
    {
        ActivateTongatong();
        Debug.Log("beat tapped");
    }

    void ActivateTongatong()
    {

        Ray ray = new Ray(this.transform.position, Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            Tongatong tongatongHit = hit.transform.gameObject.GetComponent<Tongatong>();
            tongatongHit.Interact();
        }
    }
}
