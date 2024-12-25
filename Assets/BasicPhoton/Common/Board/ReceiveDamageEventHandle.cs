using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class ReceiveDamageEventHandle : MonoBehaviourPun
{
    public BoardCtrl boardCtrl;
    void Awake()
    {
        if (this.boardCtrl != null) return;
        this.boardCtrl = GetComponent<BoardCtrl>();
    }
    private void OnEnable()
    {

        PhotonNetwork.NetworkingClient.EventReceived += ReceiveDamageEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= ReceiveDamageEvent;
    }

    private void ReceiveDamageEvent(EventData photonEvent)
    {
        if (photonEvent.Code == (byte)CreatureEvent.Code.CreatureAttack)
        {
            object[] data = (object[])photonEvent.CustomData;
            string enemyAttackName = (string)data[0];
            string creatureSufferName = (string)data[1];
            // Debug.LogError("Attacking Cre: " + enemyAttackName);
            // Debug.LogError("Suffering Cre: " + creatureSufferName);
            GameObject enemyCreatureAttack = boardCtrl.opBoard.GetComponent<SummonEventHandler>().FindEnemyCreature(enemyAttackName);
            if (enemyCreatureAttack == null) Debug.LogError("Khong tim thay quai doi thu");
            GameObject allyCreatureSuffer = boardCtrl.FindAllyCreature(creatureSufferName);
            if (allyCreatureSuffer == null) Debug.LogError("khong tim thay quai ban than");
            //bo sung logic
            CreatureDropZone allyZone = allyCreatureSuffer.GetComponentInChildren<CreatureDropZone>();
            allyZone.publicAttackAnimation(enemyCreatureAttack.transform);
            // allyZone.BothTakeDamage(enemyCreatureAttack.GetComponent<CreatureCtrl>(), allyCreatureSuffer.GetComponent<CreatureCtrl>());
        }
    }
}
