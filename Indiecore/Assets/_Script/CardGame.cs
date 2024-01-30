using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;


public class CardGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Card currentCard;
    private bool isFlipped,isFlipping = false;
    TextMeshPro nameText;
    SpriteRenderer cardSprite;
    SpriteRenderer cardBackSprite;
    private Collider2D cardCollider;
    private void Start()
    {
        Initialize();
        InitializeFeedBack();
    }
    private void Initialize()
    {
        cardSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        cardBackSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        nameText = transform.GetComponentInChildren<TextMeshPro>();
        cardCollider = transform.GetComponent<Collider2D>();
        cardCollider.isTrigger = false;
    }
    private void InitializeFeedBack()
    {
        transform.DOScale(0.3f, 0.1f).SetEase(Ease.InOutBack);
        transform.DORotateQuaternion(Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, 0), 0.2f);
    }
    private void FlipCard()
    {
        if (isFlipping)return;
        isFlipped = !isFlipped;
        DOVirtual.DelayedCall(0.06f, () =>
        {
            if (isFlipped)
            {
                cardBackSprite.enabled = true;
            }
            else
            {
                cardBackSprite.enabled = false;
            }
        });
        transform.DORotate(new Vector3(0, 180, 0), 0.2f, RotateMode.LocalAxisAdd).SetRelative(true).SetEase(Ease.OutCubic).OnComplete(
            () =>
            {
                isFlipping = false;
            });
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        FlipCard();
    }
}
