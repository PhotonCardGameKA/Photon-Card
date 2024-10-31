using Photon.Pun;
using Photon.Realtime;
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
        for (int i = 0; i < numCard; i++)
            MasterManager.NetworkInstantiate(cardPrefab, cardPrefab.transform.position, cardPrefab.transform.rotation, playerArea);
    }
}