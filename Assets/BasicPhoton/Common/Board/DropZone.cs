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
    public BoardCtrl boardCtrl;
    private void Awake()
    {
        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadCreatureSpawner();
        this.LoadBoardCtrl();
    }
    private void LoadCreatureSpawner()
    {
        if (this.creatureSpawner != null) return;
        this.creatureSpawner = GetComponent<CreatureSpawner>();
    }
    private void LoadBoardCtrl()
    {
        if (this.boardCtrl != null) return;
        this.boardCtrl = GetComponent<BoardCtrl>();
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
                string uniqueName = propOfCreature.pvOwnerId.ToString() + "_" + (System.DateTime.Now.Ticks % 10000).ToString();
                propOfCreature.objectName = uniqueName;
                GameObject newCreature = this.creatureSpawner.SpawnWithProp(propOfCreature);
                newCreature.transform.SetParent(transform, false);
                boardCtrl.UpdateListCreature();
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
            propOfCreature.pvOwnerId,
            propOfCreature.pvOPId,
            propOfCreature.objectName,
        };

        RaiseEventOptions options = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.Others
        };

        PhotonNetwork.RaiseEvent((byte)PlayerEvent.Code.SummonCreature, eventData, options, ExitGames.Client.Photon.SendOptions.SendReliable);
    }
}
