using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : _Deck
{
    void Awake()
    {
        this.TestDeck();
    }
    void TestDeck()
    {
        for (int i = 0; i < 40; i++)
        {
            int rd = Random.Range(1, 3);
            MinionCard randCard = Resources.Load<MinionCard>("CardDatabase" + "/" + rd.ToString());
            this.deck.Add(randCard);
        }
    }

    public override void Draw(int numCard)
    {
        base.Draw(numCard);
        if (this.deck.Count == 0)
        {
            Debug.Log("Out of Card ", gameObject);
            return;
        }
        for (int i = 0; i < numCard; i++)
        {
            MinionCard card = this.deck[0];
            PlayerCtrl.instance.playerHand.AddCardToHand(card);
            this.deck.RemoveAt(0);
        }

    }
    public override void Discard(int numCard)
    {
        base.Discard(numCard);
        if (this.deck.Count == 0)
        {
            Debug.Log("Out of Card ", gameObject);
            return;
        }
        for (int i = 0; i < numCard; i++)
        {
            _Card card = this.deck[0];
            PlayerCtrl.instance.playerVoid.voidCards.Add(card);
            this.deck.RemoveAt(0);
        }

    }
}
