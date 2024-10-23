using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInHandUI : MonoBehaviour
{
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescription;
    public TextMeshProUGUI cardCost;
    public TextMeshProUGUI cardHP;
    public TextMeshProUGUI cardAtk;
    public Image cardImage;
    public GameObject backGround;
    GameObject hand;
    public MinionCard inforCard;//base card
    [SerializeField] public MinionStats stats;// include current stats
    // [SerializeField] public List<int> stats;
    public void GetStats()
    {
        this.stats.card = this.inforCard;
        this.stats.ResetStats();
    }
    public void SetInformation(MinionCard card)
    {
        //update UI
        this.inforCard = card;
        this.cardName.text = inforCard.cardName;
        this.cardDescription.text = inforCard.cardDescription;
        this.cardHP.text = inforCard.hp.ToString();
        this.cardAtk.text = inforCard.atk.ToString();
        this.cardCost.text = inforCard.cost.ToString();
        this.cardImage = inforCard.image;
        //
        this.GetStats();
        hand = GameObject.Find("PlayerHand");

        transform.SetParent(hand.transform);
        transform.localScale = new Vector3(0.8f, 0.8f, 1);
    }
    //update by stats (not scripttableobject)
    public void SetInformation(MinionStats card)
    {
        this.cardHP.text = card.currentHp.ToString();
        this.cardAtk.text = card.currentAtk.ToString();
        this.cardCost.text = card.currentCost.ToString();
    }
}
