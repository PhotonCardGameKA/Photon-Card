using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
// [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class _Card : ScriptableObject
{
    [SerializeField] public int id;
    [SerializeField] public string cardName;
    [SerializeField] public int cost;
    [SerializeField] public string cardDescription;
    [SerializeField] public Image image;
    [SerializeField] public string frameColor;
    public bool isPlayed = false;
    public enum CardState
    {
        OnDeck,
        OnHand,
        OnBoard,
        OnVoid
    }
    [SerializeField] public CardState cardState;

    public virtual void Attack()
    {

    }
    // public virtual bool CanPlayCard()
    // {


    // }
    public virtual void Effect()
    {

    }

}
