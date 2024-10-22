using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int dropSlot = 6;
    public int dropCurrent = 0;
    public Draggable.SLOT typeOfItem = Draggable.SLOT.CREATURE;
    public void OnDrop(PointerEventData eventData)
    {
        if (this.dropCurrent < this.dropSlot)
        {
            Debug.Log("OnDrop to " + gameObject.name);
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                if (typeOfItem == d.typeOfItem)
                    d.parentToReturn = this.transform;
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if dropzone is full, do something
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
