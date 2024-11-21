using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonCardProp : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonCardCtrl photonCardCtrl;

    public int currentHp;
    public int maxHp;
    public int currentAtk;
    public int maxAtk;
    public bool usedThisTurn;
    void Awake()
    {
        if (this.photonCardCtrl != null) return;
        this.photonCardCtrl = GetComponentInParent<PhotonCardCtrl>();
    }
    public bool CanSelect()
    {
        return !usedThisTurn;
    }
    public bool CanAttack()
    {
        if (!this.CanSelect()) return false;
        return true;
    }
    [PunRPC]
    void takeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            photonView.RPC(nameof(this.Die), RpcTarget.All);
        }
        else
        {
            //update health ui
            this.photonCardCtrl.photonCardUI.UpdateHealthImage(damage);//rpc method
        }
    }
    [PunRPC]
    void Die()
    {
        gameObject.SetActive(false);
    }
}
