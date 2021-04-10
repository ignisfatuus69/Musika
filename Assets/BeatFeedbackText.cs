using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class BeatFeedbackText : MonoBehaviour
{
    public OnDeactivate EVT_OnDeactivate;
    
    public TextMeshProUGUI tmProComponent;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int despawnTime;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed *= Time.deltaTime;
    }

    private void OnEnable()
    {
        StartCoroutine(FeedbackTextBehavior());
    }

    void TranslateUpwards()
    {
        this.transform.position += new Vector3(0, movementSpeed);
    }

    private void Update()
    {
        TranslateUpwards();
    }

    IEnumerator FeedbackTextBehavior()
    {
        yield return new WaitForSeconds(despawnTime);
        EVT_OnDeactivate.Invoke(this.gameObject);
    }
}
