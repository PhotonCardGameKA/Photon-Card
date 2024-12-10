using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "NewCard", menuName = "Card/Creature")]
public class CardInfo : ScriptableObject
{
    public Sprite iconImage;
    public string cardName;
    public int currentHp;
    public int maxHp;
    public int currentAtk;
    public int maxAtk;
    public int cost;
    public bool usedThisTurn;
    public string description;

    public string tribe;
}