using Photon.Pun;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviourPunCallbacks
{
    private int currentPlayerTurn;
    private int currentTurn;
    public void OnClick_EndTurn()
    {
        //     currentTurn++;
        //     currentPlayerTurn = currentTurn % 2;
        //     int nextPlayerID = PhotonNetwork.PlayerList[currentPlayerTurn].ActorNumber;
        photonView.RPC(nameof(this.RPC_EndTurn), RpcTarget.All);
    }
    [PunRPC]
    public void RPC_EndTurn()
    {
        if (photonView.IsMine)
        {
            StartTurn();
        }
        else
        {
            EndTurn();
        }
    }

    private void StartTurn()
    {
        // Kích hoạt giao diện, nút, hoặc các hành động cho người chơi
        Debug.Log("It's your turn!");
    }

    private void EndTurn()
    {
        // Vô hiệu hóa giao diện, nút, hoặc các hành động cho người chơi
        Debug.Log("Waiting for other player's turn...");
    }
}