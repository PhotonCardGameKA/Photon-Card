// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager instance;
//     public int turn = 0;
//     public enum GameState
//     {
//         SelectCard,
//         PlayerTurn,
//         EnemyTurn,
//         Victory,
//         Defeat
//     }
//     public GameState gameState;
//     public static event Action<GameState> OnGameStateChanged;
//     void Awake()
//     {
//         if (instance == null)
//         {
//             GameManager.instance = this;
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }
//     void Start()
//     {
//         UpdateGameState(GameState.SelectCard);
//     }

//     public void UpdateGameState(GameState newState)
//     {
//         gameState = newState;
//         switch (newState)
//         {
//             case GameState.SelectCard:
//                 break;
//             case GameState.PlayerTurn:
//                 break;
//             case GameState.EnemyTurn:
//                 break;
//             case GameState.Victory:
//                 break;
//             case GameState.Defeat:
//                 break;
//             default:
//                 throw new ArgumentException(nameof(newState), newState.ToString(), null);

//         }
//         OnGameStateChanged?.Invoke(newState);
//     }
// }
