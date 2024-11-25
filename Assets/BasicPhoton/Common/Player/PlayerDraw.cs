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
    [PunRPC]
    private void RPC_Draw()
    {

        GameObject card;
        PhotonCardUI photonCardUI;

        Debug.Log("Draw");
        card = MasterManager.NetworkInstantiate(cardPrefab, transform.position, transform.rotation);
        listTemp.Add(card);
        photonCardUI = card.GetComponentInChildren<PhotonCardUI>();
        photonCardUI.ShowCardBack();

        card.transform.SetParent(playerArea.transform, false);
        Debug.Log("1");
        // card.transform.SetParent(playerArea.yourOPHandPrefab.transform, false);
        // Debug.Log("2");


    }
    public void DrawLocal()
    {
        GameObject cardToDraw = Instantiate(cardPrefab);
        cardToDraw.transform.SetParent(playerArea.yourHandPrefab.transform, false);
        playerArea.cardholder.Add(cardToDraw);
    }


}