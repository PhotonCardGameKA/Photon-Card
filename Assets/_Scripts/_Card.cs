using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
// [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class _Card : ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public string cardDescription;
    public Image image;
    public string frameColor;
    public virtual void Attack()
    {

    }
    public virtual void Effect()
    {

    }

}
