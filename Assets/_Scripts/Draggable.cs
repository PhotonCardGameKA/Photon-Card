using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentToReturn = null;
    [SerializeField] protected HorizontalLayoutGroup handLayoutGroup;
    [SerializeField] protected CanvasGroup canvasRaycast;
    public enum SLOT
    {
        WEAPON,
        CREATURE,
        SPELL
    };
    public SLOT typeOfItem;
    void Start()
    {
        this.handLayoutGroup = transform.parent.GetComponent<HorizontalLayoutGroup>();
        this.canvasRaycast = transform.GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("On Begin Drag");

        if (this.handLayoutGroup != null)
        {
            this.handLayoutGroup.enabled = false;
        }
        if (this.canvasRaycast != null)
        {
            this.canvasRaycast.blocksRaycasts = false;
        }
        parentToReturn = this.transform.parent;

        this.transform.SetParent(this.transform.parent.parent);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("On End Drag");

        if (this.handLayoutGroup != null)
        {
            this.handLayoutGroup.enabled = true;
        }
        if (this.canvasRaycast != null)
        {
            this.canvasRaycast.blocksRaycasts = true;
        }
        this.transform.SetParent(parentToReturn);
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("On Drag");
        this.transform.position = eventData.position;

    }
}