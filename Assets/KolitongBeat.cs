using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolitongBeat : Beat,IInteractable
{
    public Direction beatDirection;
    [SerializeField] private Transform arrowDirection;
    [SerializeField] private SpriteRenderer kolitongArrowSprite;
    [SerializeField] private SpriteRenderer kolitongBeatSprite;
    [SerializeField] private SpriteRenderer kolitongOuterCircleSprite;
    protected override void OnEnable()
    {
        base.OnEnable();
        SetOrderLayer();
        FlipArrow();
    }
    void ActivateTongatong()
    {
        Debug.Log("swiper no swiping pare");
    }

    public void SetOrderLayer()
    {
        kolitongBeatSprite.sortingOrder = beatSpawnerObj.totalSpawnsCount;
        kolitongOuterCircleSprite.sortingOrder = beatSpawnerObj.totalSpawnsCount;
        kolitongArrowSprite.sortingOrder = beatSpawnerObj.totalSpawnsCount + 1;
    }
    public void FlipArrow()
    {
        if (this.beatDirection == Direction.Left) arrowDirection.localScale = new Vector2(arrowDirection.localScale.x, 0.6f);
        if (this.beatDirection == Direction.Right) arrowDirection.localScale = new Vector2(arrowDirection.localScale.x, -0.6f);
    }
}
