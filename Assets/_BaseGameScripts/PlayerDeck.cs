using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public int randomTest;
    void Start()
    {
        randomTest = 0;
        for (int i = 0; i < 40; i++)
        {
            randomTest = Random.Range(1, 6);
            deck.Add(CardDatabase.cardList[randomTest]);
        }
    }
    public virtual void Shuffle()
    {

        for (int i = 0; i < this.deck.Count; i++)
        {
            Card tempCardShuffle = new Card();
            tempCardShuffle = deck[i];
            int randomIndex = Random.Range(i, this.deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = tempCardShuffle;
        }
    }
}
