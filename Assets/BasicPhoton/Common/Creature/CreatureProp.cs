using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureProp : MonoBehaviour
{
    [SerializeField] private CreatureCtrl creatureCtrl;
    public PhotonCardProp photonCardProp;
    public CreatureUI creatureUI;
    //prop
    public int currentHp;
    public int maxHp;
    public int currentAtk;
    public int maxAtk;
    public int cost;
    public Sprite cardIcon;
    public bool usedThisTurn;
    public string cardName;
    public string description;
    //
    private void Awake()
    {
        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadCtrl();
    }
    private void LoadCtrl()
    {
        if (this.creatureCtrl != null) return;
        this.creatureCtrl = GetComponentInParent<CreatureCtrl>();
        if (this.creatureUI != null) return;
        this.creatureUI = this.creatureCtrl.creatureUI;
    }
    public void SetCardProp(PhotonCardProp cardProp)
    {
        this.photonCardProp = cardProp;
    }
    public void SetProp()
    {
        this.currentHp = this.photonCardProp.currentHp;
        this.maxHp = this.photonCardProp.maxHp;
        this.currentAtk = this.photonCardProp.currentAtk;
        this.maxAtk = this.photonCardProp.maxAtk;
        this.cost = this.photonCardProp.cost;
        this.cardIcon = this.photonCardProp.cardIcon;
        this.cardName = this.photonCardProp.cardName;
        this.description = this.photonCardProp.description;
    }
}
