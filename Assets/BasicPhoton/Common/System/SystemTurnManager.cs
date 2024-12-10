using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class SystemTurnManager : MonoBehaviourPunCallbacks
{
    public Button changeTurnButton;
    PlayerController playerController;
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
            Debug.Log("luot cua ban");
            changeTurnButton.interactable = true;

        }
        else
        {
            Debug.Log("luot doi thu");
            changeTurnButton.interactable = false;
            // DrawOnChangeTurn();
        }
        DrawOnChangeTurn();
    }
    [PunRPC]
    private void ChangeTurnState()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2) return;
        isMyTurn = !isMyTurn;
    }

    public void OnNextTurnButtonClicked()
    {
        // DrawOnChangeTurn();
        if (!isMyTurn) return;
        Player player = GetNextPlayer();
        if (player == null) return;

        photonView.RPC(nameof(this.ChangeTurnState), RpcTarget.All);
        photonView.RPC(nameof(this.ChangeButtonState), RpcTarget.All);

    }
    void DrawOnChangeTurn()
    {//draw

        GameManager.Instance.SyncTurn(isMyTurn);
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