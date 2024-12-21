using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowDragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] GameObject blackArrow;
    [SerializeField] GameObject redArrow;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private Vector2 originalPosition;
    public bool canDrag = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag == false) return;
        blackArrow.SetActive(true);
        originalPosition = rectTransform.anchoredPosition;
        // originalParent = transform.parent;

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag == false) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag == false) return;
        canvasGroup.blocksRaycasts = true;
        blackArrow.SetActive(false);
        redArrow.SetActive(false);

        // if (transform.parent == originalParent)
        // {
        rectTransform.anchoredPosition = originalPosition;
        // }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("1");
    }

    private void DisableDrag()
    {

        canvasGroup.blocksRaycasts = true;
        enabled = false;
    }
}
