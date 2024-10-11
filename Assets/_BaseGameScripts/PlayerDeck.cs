using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int randomTest;
    void Start()
    {
        randomTest = 0;
        for (int i = 0; i < 40; i++)
        {
            randomTest = Random.Range(1, 4);
            deck[i] = CardDatabase.cardList[randomTest];
        }
    }
    protected virtual void Shuffle()
    {
        
    }
}
