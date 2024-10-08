using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardDatabase : MonoBehaviour
{
    [SerializeField]
    protected List<Card> cardList = new List<Card>();

    void Awake()
    {
        Card card = new Card(0, "test", 1, 2, "this is card");

        cardList.Add(new Card(0, "test", 1, 2, "this is card"));
        cardList.Add(new Card(0, "test", 1, 2, "this is card"));
        cardList.Add(new Card(0, "test", 1, 2, "this is card"));
        cardList.Add(new Card(0, "test", 1, 2, "this is card"));
        cardList.Add(new Card(0, "test", 1, 2, "this is card"));
        cardList.Add(new Card(0, "test", 1, 2, "this is card"));
    }
}
