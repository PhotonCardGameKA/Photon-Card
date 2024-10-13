using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite cardImage;

    [SerializeField]
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;
    public Image thisImage;

    public Image frameColor;
    public bool cardBack;
    public static bool staticCardBack;

    public GameObject hand;
    public int numberOfCardsInDecks;
    void Start()
    {
        //thisCard[0] = CardDatabase.cardList[thisId];
        // numberOfCardsInDecks = PlayerDeck.deckSize;
    }
    void FrameColor()
    {
        if (thisCard[0].color == "Green")
        {
            return;
        }
        if (thisCard[0].color == "Red")
        {
            frameColor.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        else
        if (thisCard[0].color == "Blue")
        {
            frameColor.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        else if
        (thisCard[0].color == "Yellow")
        {
            frameColor.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }
        else if
        (thisCard[0].color == "Purple")
        {
            frameColor.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
        }
    }
    void SetInformation()
    {
        hand = GameObject.Find("Hand");
        if (this.transform.parent == hand.transform.parent)
        {
            cardBack = false;
        }
        id = thisCard[0].id;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;
        cardImage = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = "" + cardDescription;
        thisImage.sprite = cardImage;

        staticCardBack = cardBack;
        FrameColor();


    }
    void Awake()
    {
        numberOfCardsInDecks = PlayerDeck.deckSize;
        this.SetInformation();
        thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDecks - 1];
        numberOfCardsInDecks--;
        PlayerDeck.deckSize--;
        cardBack = false;

    }
    void FixedUpdate()
    {
        this.SetInformation();
    }
}
