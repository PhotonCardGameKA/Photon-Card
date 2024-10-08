using System;

[Serializable]
public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Card()
    {

    }
    public Card(int Id, string CardName, int Cost, int Power, string CardDescription)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;
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
