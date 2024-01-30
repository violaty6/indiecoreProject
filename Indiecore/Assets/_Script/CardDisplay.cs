using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private bool selected, toHand = false;
    public bool _isCardInitToGame,_preview = false;
    public Card card;
    public Vector3 cardHandLocation;
    public Quaternion cardHandRotation;
    [SerializeField]  TextMeshPro nameText;
    [SerializeField]  SpriteRenderer cardImage;
    public Hand CurHand;
    private Sequence To2d3dSequence,HoldSequence;

    public void MoveToLocation()
    {
        transform.DOLocalMove(cardHandLocation, 0.5f);
        transform.DORotateQuaternion(cardHandRotation, 0.5f);
    }
    public void SetDisplay()
    {
        nameText.text = card.cardName;
        cardImage.sprite = card.cardSprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(0.36f, 0.1f).SetEase(Ease.InOutBack);
        HoldSequence.Kill();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(0.44f, 0.1f).SetEase(Ease.InOutBack);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selected || toHand) return;
        ToHover();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected || toHand) return;
        ToTheHand();
    }
    public void OnDrag(PointerEventData eventData)
    {
        selected = true;
        Vector3 mousePositionScreen = Input.mousePosition;
        mousePositionScreen.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        transform.position = mousePositionWorld;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        selected = false;
        ToTheHand();
        if (!_preview) return;
        transform.GetComponent<SortingGroup>().sortingOrder = 5;
        DOTween.Kill(transform);
        CurHand.ThrowCard(this.gameObject);
        _isCardInitToGame = true;
    }
    private void ToHover()
    {
        transform.DOLocalMoveY(cardHandLocation.y + 0.5f, 0.1f);
        transform.DORotateQuaternion(Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, 0), 0.2f);
        transform.DOScale(transform.localScale+(Vector3.one/50),0.1f);
        transform.SetAsLastSibling();
        transform.GetComponent<SortingGroup>().sortingOrder = 20;
    }
    private void ToTheHand()
    {
        toHand = true;
        transform.DOLocalMove(cardHandLocation, 0.25f).SetEase(Ease.InBack).OnComplete(() => toHand = false) ;
        transform.DORotateQuaternion(cardHandRotation, 0.2f);
        transform.DOScale(0.4f, 0.1f);
        transform.GetComponent<SortingGroup>().sortingOrder = 10;
    }
    private void OnDisable()
    { 
        DOTween.Kill(transform);
        To2d3dSequence.Kill();
        HoldSequence.Kill();
    }
}