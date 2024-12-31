using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDraw : MonoBehaviourPun
{
    [SerializeField] PlayerController playerController;
    [SerializeField] protected GameObject cardPrefab;
    [SerializeField] protected PlayerHandArea playerArea;
    // [SerializeField] List<GameObject> listTemp;
    GraveCtrl graveCtrl;
    int maxCardInHand = 7;

    IEnumerator WaitForPlayerController()
    {
        while (playerController == null || playerController.PlayerHandArea == null)
        {
            yield return null; // Chờ đến khi PlayerController và PlayerHandArea sẵn sàng
        }

        this.playerArea = playerController.PlayerHandArea;

        if (this.playerArea == null)
        {
            Debug.LogError("PlayerHandArea is not assigned!");
        }
    }
    void Awake()
    {
        this.playerController = GetComponentInParent<PlayerController>();
        LoadPlayer();
        if (graveCtrl != null) return;
        graveCtrl = GameObject.Find("GraveP").GetComponent<GraveCtrl>();
    }
    void Start()
    {
        StartCoroutine(WaitForPlayerController());
    }
    #region ref
    public CreatureProp player;
    public CreatureProp enemy;
    void LoadPlayer()
    {
        if (player == null)
        {
            player = GameObject.Find("PlayerIconE").GetComponentInChildren<CreatureProp>();
        }
        if (enemy == null)
        {
            enemy = GameObject.Find("PlayerIconE1").GetComponentInChildren<CreatureProp>();
        }
    }
    int dmg = 1;
    #endregion

    #region  draw
    private void OnEnable()
    {

        PhotonNetwork.NetworkingClient.EventReceived += minusHpEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= minusHpEvent;
    }
    private void minusHpEvent(EventData eventData)
    {
        if (eventData.Code == (byte)PlayerEvent.Code.DeductHpOutOfCards)
        {
            object[] data = (object[])eventData.CustomData;
            enemy.currentHp -= (int)data[0];
            enemy.creatureUI.SetUI();
            WinCondition.Instance.CheckHp();
        }
    }
    public void DrawLocal()
    {

        CardInfo cardInfo = playerController.PlayerDeck.Draw();
        if (cardInfo == null)
        {
            AnNotification.Instance.CustomMessage("Out of cards");
            player.currentHp -= dmg;
            object[] eventData = new object[]
            {
                dmg,
            };
            RaiseEventOptions options = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent((byte)PlayerEvent.Code.DeductHpOutOfCards, eventData, options, ExitGames.Client.Photon.SendOptions.SendReliable);
            player.creatureUI.SetUI();
            dmg++;
            WinCondition.Instance.CheckHp();
            return;
        }
        SoundManager.Instance.PlaySound("DrawCard");
        GameObject cardToDraw = Instantiate(cardPrefab);
        cardToDraw.transform.SetParent(playerArea.yourHandPrefab.transform, false);
        //set info to card draw

        cardToDraw.GetComponentInChildren<PhotonCardProp>().SetProp(cardInfo);
        cardToDraw.GetComponent<PhotonCardCtrl>().cardInfo = cardInfo;
        cardToDraw.GetComponentInChildren<PhotonCardUI>().InitUI();
        UpdateListHolder();
        //if maxcard
        if (playerArea.cardholder.Count > maxCardInHand)
        {
            AnNotification.Instance.CustomMessage("Your Hand Is Full");
            cardToDraw.transform.SetParent(graveCtrl.cardHolder.transform);
            cardToDraw.gameObject.SetActive(false);
        }
        // playerArea.cardholder.Add(cardToDraw);
        UpdateListHolder();
        graveCtrl.UpdateList();
    }
    public void UpdateListHolder()
    {
        playerArea.cardholder.Clear();
        foreach (Transform child in playerArea.transform)
        {
            playerArea.cardholder.Add(child.gameObject);
        }
    }
    #endregion

}