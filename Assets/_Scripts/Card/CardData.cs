using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CardData : CardAbstract
{
    [SerializeField] protected CardSO card;
    [SerializeField] protected TextMeshPro cardName;
    [SerializeField] protected TextMeshPro cardDescription;
    [SerializeField] protected TextMeshPro cardAttack;
    [SerializeField] protected TextMeshPro cardEffect;
    [SerializeField] protected TextMeshPro cardCost;


    [SerializeField] protected TextMeshPro cardTribe;
    [SerializeField] protected TextMeshPro cardHealth;
    [SerializeField] protected TextMeshPro cardArmor;


    [SerializeField] protected TextMeshPro cardDurability;



    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected virtual void LoadCardData()
    {
        if (this.card == null) return;

    }
    public virtual CardSO SetSO(CardSO cardSO)
    {
        this.card = cardSO;
        return this.card;
    }

}