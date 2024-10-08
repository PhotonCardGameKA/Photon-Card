using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThisCard : MonoBehaviour
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    [SerializeField]
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
    }

    void FixedUpdate()
    {
        id = thisCard[0].id;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = "" + cardDescription;
    }

}
