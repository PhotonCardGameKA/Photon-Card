using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardDatabase : MonoBehaviour
{
    [SerializeField]
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        Card card = new Card(0, "test", 1, 2, "this is card");

        cardList.Add(new Card(1, "test", 1, 2, "this is card 1"));
        cardList.Add(new Card(2, "test", 1, 2, "this is card 2"));
        cardList.Add(new Card(3, "test", 1, 2, "this is card 3"));
        cardList.Add(new Card(4, "test", 1, 2, "this is card 4"));
        cardList.Add(new Card(5, "test", 1, 2, "this is card 5"));
        cardList.Add(new Card(6, "test", 1, 2, "this is card 6"));
    }
}
