using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private CreatureSpawner creatureSpawner;
    public GameObject dropZoneEnemy;//(máy1-PZone) (máy2-EZone)
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
                //hủy card, tạm thời để active false, sau làm mộ thì cho xuống mộ
                eventData.pointerDrag.transform.SetParent(transform, false);
                eventData.pointerDrag.gameObject.SetActive(false);
                //card hủy rồi thì sum quái
                PhotonCardProp propOfCreature = eventData.pointerDrag.transform.GetComponentInChildren<PhotonCardProp>();

                GameObject newCreature = this.creatureSpawner.SpawnWithProp(propOfCreature);
                newCreature.transform.SetParent(transform, false);

                this.RaiseSummonEvent(propOfCreature);
            }


        }
    }

    private void RaiseSummonEvent(PhotonCardProp propOfCreature)
    {
        object[] eventData = new object[]
        {
            propOfCreature.currentHp,
            propOfCreature.maxHp,
            propOfCreature.currentAtk,
            propOfCreature.maxAtk,
            propOfCreature.cost,
            // propOfCreature.cardIcon,
            propOfCreature.cardName,
            propOfCreature.description,
            propOfCreature.transform.parent.name,
        };

        RaiseEventOptions options = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.Others
        };

        PhotonNetwork.RaiseEvent((byte)PlayerEvent.Code.SummonCreature, eventData, options, ExitGames.Client.Photon.SendOptions.SendReliable);
    }
}
