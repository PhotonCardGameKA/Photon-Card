using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private CreatureSpawner creatureSpawner;
    private void Awake()
    {
        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadCreatureSpawner();
    }
    private void LoadCreatureSpawner()
    {
        if (this.creatureSpawner != null) return;
        this.creatureSpawner = GetComponent<CreatureSpawner>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.tag == "Bullet")
            {
                eventData.pointerDrag.transform.SetParent(transform, false);
                eventData.pointerDrag.gameObject.SetActive(false);
                PhotonCardProp propOfCreature = eventData.pointerDrag.transform.GetComponentInChildren<PhotonCardProp>();
                GameObject newCreature = this.creatureSpawner.SpawnWithProp(propOfCreature);
                newCreature.transform.SetParent(transform, false);
            }


        }
    }
}
