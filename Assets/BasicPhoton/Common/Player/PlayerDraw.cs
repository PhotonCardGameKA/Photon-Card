using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerDraw : MonoBehaviourPunCallbacks
{
    [SerializeField] PlayerController playerController;
    [SerializeField] protected GameObject cardPrefab;
    [SerializeField] protected PlayerHandArea playerArea;
    [SerializeField] List<GameObject> listTemp;
    GameObject tempCard;

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
    }
    void Start()
    {
        StartCoroutine(WaitForPlayerController());
    }

    public void DrawLocal()
    {
        GameObject cardToDraw = Instantiate(cardPrefab);
        cardToDraw.transform.SetParent(playerArea.yourHandPrefab.transform, false);
        //set info to card draw
        CardInfo cardInfo = playerController.PlayerDeck.Draw();
        cardToDraw.GetComponentInChildren<PhotonCardProp>().SetProp(cardInfo);
        cardToDraw.GetComponent<PhotonCardCtrl>().cardInfo = cardInfo;
        cardToDraw.GetComponentInChildren<PhotonCardUI>().InitUI();

        playerArea.cardholder.Add(cardToDraw);
    }


}