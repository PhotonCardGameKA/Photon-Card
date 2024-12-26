using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public SystemTurnManager turnManager;
    private Vector2 originalPosition;
    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        turnManager = GameObject.Find("EndTurnButton").GetComponent<SystemTurnManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // if (!turnManager.isMyTurn) return;
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // if (!turnManager.isMyTurn) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // if (!turnManager.isMyTurn) return;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;


        if (transform.parent == originalParent)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
        else
        {
            DisableDrag();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("1");
    }

    private void DisableDrag()
    {

        canvasGroup.blocksRaycasts = true;
        enabled = false;
    }
}
