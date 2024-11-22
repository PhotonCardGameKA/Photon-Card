using Photon.Pun;
using Photon.Realtime;
using Unity.Mathematics;
using UnityEngine;

public class PlayerDraw : MonoBehaviourPunCallbacks
{
    [SerializeField] protected GameObject cardPrefab;
    [SerializeField] protected Transform playerArea;
    private void Start()
    {
        playerArea = PlayerController.Instance.PlayerHandArea.PlayerArea;
    }
    public void Draw(Player player, int numCard)
    {
        Debug.Log("Draw");
        // for (int i = 0; i < numCard; i++) break;
        // MasterManager.NetworkInstantiate(cardPrefab, cardPrefab.transform.position, cardPrefab.transform.rotation, playerArea);
        Transform hand = PlayerController.Instance.PlayerHandArea.transform;
        // GameObject tempCard = PhotonNetwork.Instantiate(cardPrefab.name, hand.position, hand.rotation);
        // tempCard.transform.SetParent(hand);
        MasterManager.NetworkInstantiate(cardPrefab, hand.position, hand.rotation, playerArea);

    }

}