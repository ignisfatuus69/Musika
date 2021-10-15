using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
public class BeatFeedbackText : MonoBehaviour
{
    public OnDeactivate EVT_OnDeactivate;
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private float despawnTime;
    [SerializeField] Vector3 maxTextScale;
    public SpriteRenderer spriteRendererComponent;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed *= Time.deltaTime;
    }

    private void OnEnable()
    {
        StartCoroutine(FeedbackTextBehavior());
        Pop();
        Fade();
    }


    void TranslateUpwards()
    {
        this.transform.position += new Vector3(0, movementSpeed);

    }

    private void Update()
    {
        TranslateUpwards();
    }

    private void Pop()
    {
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        this.transform.DOScale(maxTextScale, 0.5f);
    }
    private void Fade()
    {
        this.spriteRendererComponent.color = new Color(1, 1, 1);
       // this.spriteRendererComponent.DOFade(0, 0.35f);
    }
    IEnumerator FeedbackTextBehavior()
    {
        yield return new WaitForSeconds(despawnTime);
        EVT_OnDeactivate.Invoke(this.gameObject);
    }
}
