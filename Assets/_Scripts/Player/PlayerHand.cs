using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] protected List<MinionCard> cardInHand;
    public List<GameObject> cardUI;
    protected int maxCardInHand = 9;
    public GameObject hand;
    [SerializeField] GameObject cardPrefab;
    void Start()
    {
        StartCoroutine(nameof(this.StartGame));
    }

    public void AddCardToHand(MinionCard card)
    {
        this.CheckCardInHand();
        if (this.cardInHand.Count < this.maxCardInHand)
        {
            card.cardState = _Card.CardState.OnHand;
            this.cardInHand.Add(card);
            this.CardUI(card);
        }
        else
        {
            this.DisCard(card);
        }
    }
    protected void CheckCardInHand()
    {
        int cardIDToRemove = 10;
        int size = this.cardUI.Count;
        for (int i = 0; i < size; i++)
        {
            GameObject card = this.cardUI[i];
            if (card.GetComponent<CardInHandUI>().stats.isPlayed)
            {
                cardIDToRemove = this.cardUI.IndexOf(card);
                this.cardInHand.RemoveAt(cardIDToRemove);
                this.cardUI.Remove(card);
                size--;
                i--;
            }
        }
    }
    public void DisCard(MinionCard card)
    {
        PlayerCtrl.instance.playerVoid.voidCards.Add(card);
        card.cardState = _Card.CardState.OnVoid;
    }
    public void PlayCard(int index)
    {
        this.cardInHand.RemoveAt(index);
    }
    protected virtual void CardUI(MinionCard card)
    {
        GameObject temp = Instantiate(cardPrefab, transform.position, transform.rotation);

        temp.GetComponent<CardInHandUI>().SetInformation(card);
        temp.GetComponent<CardInHandUI>().backGround.SetActive(false);
        temp.transform.SetParent(hand.transform, false);
        this.cardUI.Add(temp);

        temp.transform.SetParent(GameObject.Find("PlayerHand").transform);
        temp.transform.localScale = new Vector3(0.8f, 0.8f, 1);
    }
    IEnumerator StartGame()

    {
        for (int i = 0; i <= 4; i++)
        {

            yield return new WaitForSeconds(1);
            PlayerCtrl.instance.playerDeck.Draw(1);
            // GameObject temp = Instantiate(cardPrefab, transform.position, transform.rotation);
            // temp.GetComponent<CardInHandUI>().SetInformation(cardInHand[i]);
            // temp.GetComponent<CardInHandUI>().backGround.SetActive(false);


        }
    }


}
