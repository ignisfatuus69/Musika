using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gabbang : BeatInteractor
{

    public void DetectBeats(Vector3 touchPosition)
    {

        Ray ray = new Ray(touchPosition, Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 55, Color.blue);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            if (hit.transform.gameObject.GetComponent<Beat>() == null) return;
            Beat beatHit = hit.transform.gameObject.GetComponent<Beat>();

            EvaluateBeatState(beatHit);

        }
    }
}
