using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected int dropSlot = 6;
    public int dropCurrent = 0;
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject cardToDrop = eventData.pointerDrag;//return cardprefab clone
        CardInHandUI cardInHandUI = cardToDrop.GetComponent<CardInHandUI>();
        if (!cardInHandUI.stats.canPlayed()) return;
        if (this.dropCurrent >= this.dropSlot) return;

        Debug.Log("OnDrop to " + gameObject.name);
        cardInHandUI.stats.playeThisCard();
        cardInHandUI.stats.state = _Card.CardState.OnBoard;
        Draggable d = cardToDrop.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturn = this.transform;
            dropCurrent++;
        }



        // eventData.pointerDrag.transform.SetParent(transform);
        //StartCoroutine(DisableDraggable(d));//ensure that the placeholder in hand will be destroyed
    }
    IEnumerator DisableDraggable(Draggable d)
    {
        yield return new WaitForSeconds(1);
        d.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        // Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        // if (d != null)
        // {
        //     d.placeHolderParent = this.transform;
        // }

        //if dropzone is full, do something
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        // Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        // if (d != null && d.placeHolderParent == this.transform)
        // {
        //     d.placeHolderParent = d.parentToReturn;
        // }
    }
}
