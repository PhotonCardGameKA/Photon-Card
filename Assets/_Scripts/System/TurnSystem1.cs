// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TurnSystem : MonoBehaviour
// {
//     public void OnChangeTurn()
//     {
//         if (GameManager.instance.turn % 2 == 0)
//         {
//             PlayerCtrl.instance.playerDeck.Draw(1);
//             PlayerCtrl.instance.playerMana.AddMana(1);
//             PlayerCtrl.instance.playerMana.ResetMana();
//             PlayerCtrl.instance.playerMana.UpdateUI();
//         }
//         GameManager.instance.turn++;
//     }
// }
