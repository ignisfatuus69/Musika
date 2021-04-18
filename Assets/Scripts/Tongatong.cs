﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongatong : BeatInteractor
{
    public KeyCode InputCode;
    public float speed = 5;
    public float displacement = 20;
    private Vector2 InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        speed *= Time.fixedDeltaTime;
        displacement *= Time.fixedDeltaTime;
        InitialPosition = transform.position;
    }

    private void MoveDown()
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

        transform.position = targetPosition;

        //object snaps back up
        if (displacementOverTime > 0)
        {
            StartCoroutine(MoveToDisplacement(0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Tongatong PC Controls
        if (Input.GetKeyDown(InputCode))
        {
            MoveDown();
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
    }

}
