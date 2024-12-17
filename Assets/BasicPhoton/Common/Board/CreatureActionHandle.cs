using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class CreatureActionHandle : MonoBehaviourPun
{
    // public CreatureCtrl creatureCtrl;
    public BoardCtrl boardCtrl;
    private void Awake()
    {
        if (this.boardCtrl != null) return;
        this.boardCtrl = GetComponentInParent<BoardCtrl>();
        // if (this.creatureCtrl != null) return;
        // this.creatureCtrl = GetComponentInParent<CreatureCtrl>();
    }
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += ReceiveDamageEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= ReceiveDamageEvent;
    }

    public void ReceiveDamageEvent(EventData photonEvent)
    {
        if (photonEvent.Code == (byte)CreatureEvent.Code.SendDamage)
        {
            object[] data = (object[])photonEvent.CustomData;
            int attackingCreatureHp = (int)data[1];
            int attackingCreatureDmg = (int)data[2];
            string receiverName = (string)data[0];//name of object
            GameObject damageReceiver = boardCtrl.FindCreature(receiverName);
            CreatureCtrl receiverCtrl = damageReceiver.GetComponent<CreatureCtrl>();
            receiverCtrl.creatureProp.TakeDamage(attackingCreatureDmg);
            receiverCtrl.creatureUI.SetUI();
        }
    }

    // public void ReceiveDamageEvent(EventData photonEvent)
    // {
    //     if (photonEvent.Code == (byte)CreatureEvent.Code.ReceiveDamage)
    //     {

    //     }
    // }

}
