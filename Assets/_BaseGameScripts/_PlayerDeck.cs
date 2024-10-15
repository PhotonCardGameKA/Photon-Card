// using System.Collections;
// using System.Collections.Generic;
// using Unity.Collections;
// using UnityEngine;

// public class _PlayerDeck : MonoBehaviour
// {
//     public List<Card> deck = new List<Card>();
//     public static List<Card> staticDeck = new List<Card>();
//     public int randomTest;
//     public GameObject deckCardImage1;
//     public GameObject deckCardImage2;
//     public GameObject deckCardImage3;
//     public GameObject deckCardImage4;
//     public static int deckSize;
//     public GameObject hand;
//     public GameObject cardToHand;

//     void Start()
//     {
//         randomTest = 0;
//         for (int i = 0; i < 40; i++)
//         {
//             randomTest = Random.Range(0, 5);
//             deck.Add(CardDatabase.cardList[randomTest]);
//             staticDeck.Add(CardDatabase.cardList[randomTest]);
//         }

//         deckSize = deck.Count;
//         StartCoroutine(StartGame());
//     }



//     IEnumerator StartGame()
//     {
//         for (int i = 0; i <= 4; i++)
//         {
//             yield return new WaitForSeconds(1);

//             GameObject temp = Instantiate(cardToHand, hand.transform.position, hand.transform.rotation);
//             ThisCard cardInfor = temp.GetComponent<ThisCard>();
//             cardInfor.thisCard[0] = deck[i];

//             temp.transform.SetParent(hand.transform, false);

//         }
//     }
//     void FixedUpdate()
//     {
//         staticDeck = deck;
//         if (this.deck.Count < 30)
//         {
//             this.deckCardImage1.SetActive(false);
//         }
//         if (this.deck.Count < 20)
//         {
//             this.deckCardImage2.SetActive(false);
//         }
//         if (this.deck.Count < 2)
//         {
//             this.deckCardImage3.SetActive(false);
//         }
//         if (this.deck.Count < 1)
//         {
//             this.deckCardImage4.SetActive(false);
//         }
//     }

//     public virtual void Shuffle()
//     {

//         for (int i = 0; i < this.deck.Count; i++)
//         {
//             Card tempCardShuffle = new Card();
//             tempCardShuffle = deck[i];
//             int randomIndex = Random.Range(i, this.deck.Count);
//             deck[i] = deck[randomIndex];
//             deck[randomIndex] = tempCardShuffle;
//         }
//     }
// }
