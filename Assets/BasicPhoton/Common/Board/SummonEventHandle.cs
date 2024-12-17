using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class SummonEventHandler : MonoBehaviourPun
{
    [SerializeField] private CreatureSpawner creatureSpawner;
    public GameObject dropZoneEnemy;
    public CardInfo[] allCard;
    public void LoadCardData()
    {
        this.allCard = Resources.LoadAll<CardInfo>("CardDatabase");
    }
    private void Awake()
    {
        this.LoadCardData();
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

            object[] data = (object[])photonEvent.CustomData;
            int currentHp = (int)data[0];
            int maxHp = (int)data[1];
            int currentAtk = (int)data[2];
            int maxAtk = (int)data[3];
            int cost = (int)data[4];
            // Sprite sprite = (Sprite)data[5];
            string cardName = (string)data[5];
            string description = (string)data[6];
            string creatureName = (string)data[7];
            Sprite sprite = FindSpriteByName(cardName);
            PhotonCardProp prop = new PhotonCardProp();

            prop.currentHp = currentHp;
            prop.maxHp = maxHp;
            prop.cardIcon = sprite;
            prop.currentAtk = currentAtk;
            prop.maxAtk = maxAtk;
            prop.cost = cost;
            prop.cardName = cardName;
            prop.description = description;

            GameObject newCreature = this.creatureSpawner.SpawnWithProp(prop);
            newCreature.name = creatureName;
            newCreature.transform.SetParent(dropZoneEnemy.transform, false);
        }
    }
}
