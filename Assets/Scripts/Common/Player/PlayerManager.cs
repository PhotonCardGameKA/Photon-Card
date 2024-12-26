using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public PlayerController playerController;
    public GameObject opRefLocal;
    public PlayerDeck yourDeckNetwork;
    #region player
    public bool isMyTurn = false;
    public int maxHp = 30;
    public int currentHp = 30;
    public int pAtk = 0;
    public int cardInHand = 0;
    public int maxCardInHand = 8;
    public int currentMp = 0;
    public int unlockedMp = 1;
    public int maxMp = 9;
    public List<CardInfo> deck;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    bool isDefeated()
    {
        return (currentHp <= 0);
    }
    void actionDefeated()
    {

    }
    void takeDamage(int dmg)
    {
        if (this.currentHp - dmg > 0) this.currentHp -= dmg;
        else
        {
            this.currentHp = 0;
            actionDefeated();
        }
    }
    void refreshMp(int mp)
    {
        if (currentMp + mp > unlockedMp) currentMp = unlockedMp;
        else currentMp += mp;
    }
    void unlockMp(int mp)
    {
        if (this.unlockedMp + mp > maxMp) this.unlockedMp = maxMp;
        else this.unlockedMp += mp;
    }
    void healCharacter(int healAmount)
    {
        if (currentHp + healAmount > maxHp) currentHp = maxHp;
        else currentHp += healAmount;
    }
    #endregion
    [PunRPC]
    void RPC_SyncOp()
    {
        foreach (int pvId in GameManager.Instance.playerRef)
        {
            if (photonView.ViewID != pvId)
            {
                PhotonView opView = PhotonView.Find(pvId);
                this.opRefLocal = opView.gameObject;
            }
        }
    }
    [PunRPC]
    void RPC_SendDeck(List<int> l)
    {
        if (photonView.IsMine)
        {

        }
    }
}