using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public int startCard = 30;
    public int currentCard = 30;
    public List<CardInfo> deck;
    public CardInfo[] allCard;
    public void LoadCardData()
    {
        this.allCard = Resources.LoadAll<CardInfo>("CardDatabase");
    }
    public void InitDeck()
    {
        for (int i = 0; i < startCard; i++)
        {
            int rd = Random.Range(0, allCard.Length);
            CardInfo tempCard = allCard[rd];
            deck.Add(tempCard);
        }
    }
    void Awake()
    {
        this.LoadCardData();
        this.InitDeck();
    }
    public CardInfo Draw()
    {
        CardInfo res = deck[0];
        deck.RemoveAt(0);
        this.currentCard--;
        return res;

    }
    public CardInfo Discard()
    {
        CardInfo res = deck[0];
        deck.RemoveAt(0);
        this.currentCard--;
        return res;
    }
}
