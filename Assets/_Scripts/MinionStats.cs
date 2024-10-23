using System;
using UnityEngine;

[Serializable]
public class MinionStats
{
    protected int atkBase;
    [SerializeField] public int currentAtk;
    protected int hpBase;
    [SerializeField] public int currentHp;
    protected int costBase;
    [SerializeField] public int currentCost;
    public _Card.CardState state;
    [SerializeField] public MinionCard card;
    public bool isPlayed;

    void Awake()
    {
        this.ResetStats();
    }
    public void ResetStats()
    {
        this.atkBase = card.atk;
        this.currentAtk = atkBase;
        this.hpBase = card.hp;
        this.currentHp = hpBase;
        this.costBase = card.cost;
        this.currentCost = costBase;
        this.state = card.cardState;
        this.isPlayed = card.isPlayed;
    }
    public bool canPlayed()
    {
        int playerMana = PlayerCtrl.instance.playerMana.currentMana;
        return playerMana >= this.currentCost;
    }
    public void playeThisCard()
    {
        if (this.canPlayed())
        {
            PlayerCtrl.instance.playerMana.UseMana(this.currentCost);
            this.isPlayed = true;
        }
    }
}