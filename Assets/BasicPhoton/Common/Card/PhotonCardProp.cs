using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PhotonCardProp : MonoBehaviour
{
    [SerializeField] private PhotonCardCtrl photonCardCtrl;
    [SerializeField] private PhotonCardUI photonCardUI;
    // public CardInfo cardInfo;
    public string objectName;
    public int pvOwnerId;
    public int pvOPId;
    public int currentHp;
    public int maxHp;
    public int currentAtk;
    public int maxAtk;
    public int cost;
    public Sprite cardIcon;
    public bool usedThisTurn;
    public string cardName;
    public string description;
    public void SetProp(CardInfo cardInfo)//use for init and reset
    {
        this.SetPvId();
        this.currentHp = cardInfo.currentHp;
        this.maxHp = cardInfo.maxHp;
        this.currentAtk = cardInfo.currentAtk;
        this.maxAtk = cardInfo.maxAtk;
        this.cost = cardInfo.cost;
        this.cardName = cardInfo.cardName;
        this.description = cardInfo.description;
        this.cardIcon = cardInfo.iconImage;
    }
    public void SetPvId()
    {
        if (GameManager.Instance.P1.IsMine)
        {
            pvOwnerId = GameManager.Instance.P1.ViewID;
            pvOPId = GameManager.Instance.P2.ViewID;
        }
        else
        {
            pvOPId = GameManager.Instance.P1.ViewID;
            pvOwnerId = GameManager.Instance.P2.ViewID;
        }
    }
    void Awake()
    {
        if (this.photonCardCtrl != null) return;
        this.photonCardCtrl = GetComponentInParent<PhotonCardCtrl>();
        if (this.photonCardCtrl == null)
        {
            Debug.Log("null");
        }
        else
        {
            this.photonCardUI = photonCardCtrl.transform.GetComponentInChildren<PhotonCardUI>();
            this.SetProp(photonCardCtrl.cardInfo);
        }

    }

}
