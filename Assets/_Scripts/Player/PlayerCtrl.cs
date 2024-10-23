using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;
    public PlayerDeck playerDeck;
    public PlayerHand playerHand;
    public PlayerBoard playerBoard;
    public PlayerVoid playerVoid;
    public CardInHandUI cardInHandUI;
    public PlayerMana playerMana;
    void Reset()
    {
        this.LoadComponents();
    }
    void Awake()
    {
        if (instance == null)
        {
            PlayerCtrl.instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        this.LoadComponents();
    }
    void LoadComponents()
    {
        this.LoadPlayerBoard();
        this.LoadPlayerHand();
        this.LoadPlayerDeck();
        this.LoadPlayerVoid();
        this.LoadCardInHandUI();
        this.LoadPlayerMana();
    }

    void LoadPlayerBoard()
    {
        if (this.playerBoard != null) return;
        this.playerBoard = transform.GetComponentInChildren<PlayerBoard>();
        Debug.Log(transform.name + "LoadPlayerBoard : ", gameObject);

    }
    void LoadPlayerHand()
    {
        if (this.playerHand != null) return;
        this.playerHand = transform.GetComponentInChildren<PlayerHand>();
        Debug.Log(transform.name + "LoadPlayerHand : ", gameObject);

    }

    void LoadPlayerDeck()
    {
        if (this.playerDeck != null) return;
        this.playerDeck = transform.GetComponentInChildren<PlayerDeck>();
        Debug.Log(transform.name + "LoadPlayerDeck : ", gameObject);

    }
    void LoadPlayerVoid()
    {
        if (this.playerVoid != null) return;
        this.playerVoid = transform.GetComponentInChildren<PlayerVoid>();
        Debug.Log(transform.name + "LoadPlayerVoid : ", gameObject);

    }
    void LoadCardInHandUI()
    {
        if (this.cardInHandUI != null) return;
        this.cardInHandUI = transform.GetComponentInChildren<CardInHandUI>();
        Debug.Log(transform.name + "LoadUICard : ", gameObject);
    }
    void LoadPlayerMana()
    {
        if (this.playerMana != null) return;
        this.playerMana = transform.GetComponentInChildren<PlayerMana>();
        Debug.Log(transform.name + "LoadMana : ", gameObject);
    }
}
