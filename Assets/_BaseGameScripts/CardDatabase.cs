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
        Sprite temp = Resources.Load<Sprite>("CardBack");

        cardList.Add(new Card(1, "test", 1, 2, "this is card 1", temp, "Red"));
        cardList.Add(new Card(2, "test", 1, 2, "this is card 2", temp, "Blue"));
        cardList.Add(new Card(3, "test", 1, 2, "this is card 3", temp, "Green"));
        cardList.Add(new Card(4, "test", 1, 2, "this is card 4", temp, "Yellow"));
        cardList.Add(new Card(5, "test", 1, 2, "this is card 5", temp, "Purple"));
        cardList.Add(new Card(6, "test", 1, 2, "this is card 6", temp, "pink"));
    }
}
