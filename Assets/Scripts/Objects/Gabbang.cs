using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gabbang : BeatInteractor
{

    [SerializeField] public InputController inputControllerObj;
    private void Start()
    {
        inputControllerObj.EVT_OnStartTouch.AddListener(PlayGabbang);
    }

    public void PlayGabbang(Vector2 position, float time)
    {
        Ray ray = new Ray(new Vector3(inputControllerObj.PrimaryPosition().x,inputControllerObj.PrimaryPosition().y,-10), Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 55, Color.blue);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            if (hit.transform.gameObject.GetComponent<Beat>() == null) return;
            Beat beatHit = hit.transform.gameObject.GetComponent<Beat>();

            EvaluateBeatState(beatHit);

        }

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            if (hit.transform.gameObject.GetComponent<Animator>() == null) return;
            Debug.Log("Play Animation");
            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }

}
