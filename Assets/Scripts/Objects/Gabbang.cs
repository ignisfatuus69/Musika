using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabbang : BeatInteractor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectBeats(Vector3 touchPosition)
    {
        Ray ray = new Ray(touchPosition, Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            Debug.Log("hit something");
            Beat beatHit = hit.transform.gameObject.GetComponent<Beat>();
            EvaluateBeatState(beatHit);

        }
    }
}
