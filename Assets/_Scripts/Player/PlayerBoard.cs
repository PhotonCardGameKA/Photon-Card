using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBoard : DropZone
{

    void Start()
    {
        this.dropSlot = 6;
        this.dropCurrent = 0;
    }
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }
}
