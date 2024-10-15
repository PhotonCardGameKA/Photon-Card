using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
[CreateAssetMenu(fileName = "New Card", menuName = "Card/MinionCard")]
public class MinionCard : _Card
{
    public int atk;
    public int hp;
    public override void Attack()
    {
        base.Attack();
    }
    public override void Effect()
    {
        base.Effect();
    }
    public MinionCard(int Id, string CardName, int Cost, int Hp, int Atk, string CardDescription, Image image, string Color)
    {
        this.id = Id;
        this.cardName = CardName;
        this.cost = Cost;
        this.cardDescription = CardDescription;
        this.image = image;
        this.frameColor = Color;
        this.hp = Hp;
        this.atk = Atk;
    }
}
