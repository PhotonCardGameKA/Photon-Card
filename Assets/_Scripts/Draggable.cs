using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentToReturn = null;
    public Transform placeHolderParent = null;
    GameObject placeHolder = null;
    // [SerializeField] protected HorizontalLayoutGroup handLayoutGroup;
    [SerializeField] protected CanvasGroup canvasRaycast;

    void Start()
    {
        // this.handLayoutGroup = transform.parent.GetComponent<HorizontalLayoutGroup>();
        this.canvasRaycast = transform.GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());


        if (this.canvasRaycast != null)
        {
            this.canvasRaycast.blocksRaycasts = false;
        }
        parentToReturn = this.transform.parent;
        placeHolderParent = parentToReturn;

        this.transform.SetParent(this.transform.parent.parent);
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        if (this.canvasRaycast != null)
        {
            this.canvasRaycast.blocksRaycasts = true;
        }
        this.transform.SetParent(parentToReturn);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        // PlayerCtrl.instance.playerHand.PlayCard(this.transform.GetSiblingIndex());
        Destroy(placeHolder);
    }
    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;
        if (placeHolder.transform.parent != placeHolderParent)
        {
            placeHolder.transform.SetParent(placeHolderParent);
        }

        int newSiblingIndex = placeHolderParent.childCount;

        for (int i = 0; i < placeHolderParent.childCount; i++)
        {

            if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);

    }
}