using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/CardData", order = 1)]
public class CardSO : ScriptableObject
{
    // 1) for all type of card
    public CardType cardType;
    public string cardName;
    public string cardDescription;
    public string cardEffect;
    public int cardCost;
    public int cardAttack;
    // 2) for creature only
    public string cardTribe;
    public int cardHealth;
    public int cardArmor;

    // 3) for weapon only
    public int cardDurability;

}
