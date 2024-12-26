using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private const string LEVEL = "level";
    private const string TEAM = "team";
    private const int MAX_PLAYERS = 2;
    private ChessLevel playerLevel;
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    [SerializeField] private BMenuUI uiManager;
    private void Update()
    {
        uiManager.SetConnectionStatus(PhotonNetwork.NetworkClientState.ToString());
    }
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.LogError($"connected to server. looking for random room with {playerLevel} level");
            PhotonNetwork.JoinRandomRoom(new ExitGames.Client.Photon.Hashtable() { { LEVEL, playerLevel } }, MAX_PLAYERS);
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }

    }
    #region  Photon CallBacks
    public override void OnConnectedToMaster()
    {
        Debug.LogError($"connected to server. looking for random room with {playerLevel} level");
        PhotonNetwork.JoinRandomRoom(new ExitGames.Client.Photon.Hashtable() { { LEVEL, playerLevel } }, MAX_PLAYERS);

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError($"join fail : {message}. create new one with {playerLevel} level");
        PhotonNetwork.CreateRoom(null, new RoomOptions
        {
            CustomRoomPropertiesForLobby = new string[] { LEVEL },
            MaxPlayers = MAX_PLAYERS,
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { LEVEL, playerLevel } }
        });
    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"player {PhotonNetwork.LocalPlayer.ActorNumber} join room {(ChessLevel)PhotonNetwork.CurrentRoom.CustomProperties[LEVEL]}");
        PrepareTeamSelectionOptions();
        uiManager.ShowTeamSelectionScreen();
    }
    private void PrepareTeamSelectionOptions()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            var firstPlayer = PhotonNetwork.CurrentRoom.GetPlayer(1);
            if (firstPlayer.CustomProperties.ContainsKey(TEAM))
            {
                var occupiedTeam = firstPlayer.CustomProperties[TEAM];
                uiManager.RestrictTeamChoice((TeamSelector)occupiedTeam);
            }
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogError($"player {newPlayer.ActorNumber} join room");
    }
    public void SetPlayerLevel(ChessLevel level)
    {
        playerLevel = level;
        PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { LEVEL, level } });
    }

    internal void SelectTeam(int team)
    {
        PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { TEAM, team } });
    }
    #endregion
}
