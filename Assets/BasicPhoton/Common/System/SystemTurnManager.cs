using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class SystemTurnManager : MonoBehaviourPunCallbacks
{
    public Button changeTurnButton;
    public bool isMyTurn = false;//local
    void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            InitSetTurn(PhotonNetwork.LocalPlayer);//chu phong di truoc
        }
        else
        {
            InitSetTurn(null);
        }


    }
    private void InitSetTurn(Player player)
    {
        if (PhotonNetwork.LocalPlayer == player)
        {
            isMyTurn = true;
            changeTurnButton.interactable = true;
        }
        else
        {
            isMyTurn = false;
            changeTurnButton.interactable = false;
        }
    }

    [PunRPC]
    private void ChangeButtonState()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2) return;
        if (isMyTurn)
        {
            Debug.Log("P2");
            changeTurnButton.interactable = true;
            DrawOnChangeTurn();
        }
        else
        {
            Debug.Log("P1");
            changeTurnButton.interactable = false;
            DrawOnChangeTurn();
        }
    }
    [PunRPC]
    private void ChangeTurnState()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2) return;
        isMyTurn = !isMyTurn;
    }

    public void OnNextTurnButtonClicked()
    {

        if (!isMyTurn) return;
        Player player = GetNextPlayer();
        if (player == null) return;
        // Debug.Log(player.NickName + " Turn");
        photonView.RPC(nameof(this.ChangeTurnState), RpcTarget.All);
        photonView.RPC(nameof(this.ChangeButtonState), RpcTarget.All);

        // PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable{
        //     {"currentPlayerTurn", GetNextPlayer().ActorNumber}
        // });
    }
    void DrawOnChangeTurn()
    {
        PlayerController.Instance.PlayerDraw.Draw(PhotonNetwork.LocalPlayer, 1);
    }
    private Player GetNextPlayer()
    {
        Player currentPlayer = PhotonNetwork.LocalPlayer;

        if (PhotonNetwork.IsMasterClient)
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                if (!player.IsMasterClient)
                {
                    return player;
                }
            }
        }
        else
        {
            return PhotonNetwork.MasterClient;
        }

        return null;
    }


}