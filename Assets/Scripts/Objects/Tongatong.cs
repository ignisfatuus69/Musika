using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongatong : BeatInteractor,IInteractable
{
    public float speed = 5;
    public float displacement = 20;
    private Vector2 InitialPosition;
    [SerializeField] private Animator tongatongAnimator;
    // Start is called before the first frame update
    void Start()
    {
        speed *= Time.fixedDeltaTime;
        displacement *= Time.fixedDeltaTime;
        InitialPosition = transform.position;
    }

    public void MoveDown()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToDisplacement(displacement));
    }

    IEnumerator MoveToDisplacement(float displacementOverTime)
    {
        Vector2 targetPosition = new Vector2(transform.position.x, InitialPosition.y - displacementOverTime);

        float distance = Vector2.Distance(transform.position, targetPosition);

        while (Vector2.Distance(transform.position, targetPosition) > 0.1)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }


        //object snaps back up
        if (displacementOverTime > 0)
        {
           
            targetPosition = InitialPosition;
            Vector2.MoveTowards(transform.position, InitialPosition, speed * Time.deltaTime);
            StartCoroutine(MoveToDisplacement(0));
            tongatongAnimator.SetTrigger("Triggered");
        }
    }

    void DetectBeats()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25))
        {
            Debug.Log("hit something");
            Beat beatHit = hit.transform.gameObject.GetComponent<Beat>();
            EvaluateBeatState(beatHit);

        }
    }

    public void OnTapAction()
    {
        MoveDown();
        DetectBeats();
    }


}
