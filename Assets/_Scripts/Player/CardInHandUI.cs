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
    public void SetInformation(MinionCard card)
    {
        this.cardName.text = card.cardName;
        this.cardDescription.text = card.cardDescription;
        this.cardHP.text = card.hp.ToString();
        this.cardAtk.text = card.atk.ToString();
        this.cardCost.text = card.cost.ToString();
        this.cardImage = card.image;

        hand = GameObject.Find("PlayerHand");

        transform.SetParent(hand.transform);
        transform.localScale = new Vector3(0.8f, 0.8f, 1);
    }
    //     void Update()
    //     {
    //         hand = GameObject.Find("PlayerHand");

    //         transform.SetParent(hand.transform);
    //         transform.localScale = new Vector3(0.8f, 0.8f, 1);
    //     }
}
