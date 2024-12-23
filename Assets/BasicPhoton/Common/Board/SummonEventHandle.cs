using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections.Generic;


public class SummonEventHandler : MonoBehaviourPun
{
    [SerializeField] private CreatureSpawner creatureSpawner;
    public GameObject dropZoneEnemy;
    public CardInfo[] allCard;
    public GameObject propHolder;
    public List<GameObject> enemyCreatureHolder;
    [SerializeField] GameObject enemyLocalHand;

    public void UpdateListCreature()
    {
        enemyCreatureHolder.Clear();
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("EnemyCreature") && child.gameObject.activeSelf)
            {
                enemyCreatureHolder.Add(child.gameObject);
            }
        }
    }
    public GameObject FindEnemyCreature(string name)
    {
        foreach (GameObject child in enemyCreatureHolder)
        {
            if (child.name == name) return child;
        }
        return null;
    }
    public void LoadCardData()
    {
        this.allCard = Resources.LoadAll<CardInfo>("CardDatabase");
    }
    private void Awake()
    {
        this.LoadCardData();
        this.enemyLocalHand = GameObject.Find("EnemyLocal");
        UpdateListCreature();
    }
    public Sprite FindSpriteByName(string name)
    {
        foreach (CardInfo card in allCard)
        {
            if (card.name == name)
            {
                return card.iconImage;
            }
        }
        return null;
    }
    private void OnEnable()
    {
        this.LoadComponents();
        PhotonNetwork.NetworkingClient.EventReceived += OnPhotonEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnPhotonEvent;
    }

    private void LoadComponents()
    {
        if (this.creatureSpawner == null)
        {
            this.creatureSpawner = GetComponent<CreatureSpawner>();
        }
        if (this.dropZoneEnemy == null)
        {
            this.dropZoneEnemy = GameObject.Find("DropZoneE");
        }
    }

    private void OnPhotonEvent(EventData photonEvent)
    {
        if (photonEvent.Code == (byte)PlayerEvent.Code.SummonCreature)
        {
            TimerManager.Instance.isStop = true;
            TimerManager.Instance.BonusTime();
            object[] data = (object[])photonEvent.CustomData;
            int currentHp = (int)data[0];
            int maxHp = (int)data[1];
            int currentAtk = (int)data[2];
            int maxAtk = (int)data[3];
            int cost = (int)data[4];
            int ownerId = (int)data[7];
            // Sprite sprite = (Sprite)data[5];
            string cardName = (string)data[5];
            string description = (string)data[6];
            int opId = (int)data[8];
            string objectName = (string)data[9];
            Sprite sprite = FindSpriteByName(cardName);
            // GameObject temp = new GameObject("temp");
            // temp.AddComponent<PhotonCardProp>();
            PhotonCardProp prop = propHolder.GetComponent<PhotonCardProp>();
            prop.pvOwnerId = ownerId;
            prop.currentHp = currentHp;
            prop.maxHp = maxHp;
            prop.cardIcon = sprite;
            prop.currentAtk = currentAtk;
            prop.maxAtk = maxAtk;
            prop.cost = cost;
            prop.cardName = cardName;
            prop.description = description;
            prop.pvOPId = opId;
            prop.objectName = objectName;
            GameObject newCreature = this.creatureSpawner.SpawnWithProp(prop);
            EnemyCardInHand enemyCardInHand = this.enemyLocalHand.GetComponentInChildren<EnemyCardInHand>();

            enemyCardInHand.UpdateList();
            enemyCardInHand.RemoveOneCard();

            newCreature.transform.SetParent(dropZoneEnemy.transform, false);
            this.UpdateListCreature();
            TimerManager.Instance.isStop = false;
        }
    }
}
