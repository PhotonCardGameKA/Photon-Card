using System;
using UnityEngine;

[Serializable]
public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite thisImage;
    public string color;
    public Card()
    {

    }
    public Card(int Id, string CardName, int Cost, int Power, string CardDescription, Sprite image, string Color)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;
        thisImage = image;
        color = Color;
    }
    public Card(Card card)
    {
        id = card.id;
        cardName = card.cardName;
        cost = card.cost;
        power = card.power;
        cardDescription = card.cardDescription;
    }
}
