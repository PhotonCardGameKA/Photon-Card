// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;

// public class TurnSystem : MonoBehaviour
// {
//     public TextMeshProUGUI turnText;
//     public TextMeshProUGUI manaText;
//     public bool isYourTurn;
//     public int yourOpponentTurn;
//     public int yourTurn;
//     public int maxMana;
//     public int currentMana;

//     // Start is called before the first frame update
//     void Start()
//     {
//         isYourTurn = true;
//         yourTurn = 1;
//         yourOpponentTurn = 0;

//         maxMana = 1;
//         currentMana = 1;

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (isYourTurn)
//         {
//             turnText.text = "Your Turn";
//         }
//         else
//         {
//             turnText.text = "Your opponent turn";
//         }

//     }
//     public void EndYourTurn()
//     {
//         isYourTurn = false;
//         yourOpponentTurn++;
//     }
//     public void EndYourOpponentTurn()
//     {
//         isYourTurn = true;
//         yourTurn++;
//         maxMana++;
//         currentMana++;
//         manaText.text = currentMana + "/" + maxMana;
//     }

// }
