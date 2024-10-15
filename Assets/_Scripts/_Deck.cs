using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _Deck : MonoBehaviour
{
    public List<MinionCard> deck;
    void Awake()
    {

    }

    public virtual void Shuffle()
    {
        for (int i = 0; i < this.deck.Count; i++)
        {
            MinionCard tempCardShuffle;
            tempCardShuffle = deck[i];
            int randomIndex = Random.Range(i, this.deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = tempCardShuffle;
        }
    }
    public virtual void Draw(int numCard)
    {

    }
    public virtual void Discard(int numCard)
    {

    }

}
