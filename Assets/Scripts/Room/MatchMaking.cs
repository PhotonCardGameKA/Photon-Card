
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MatchMaking : MonoBehaviourPunCallbacks

{
    #region  Match Making Create
    public void OnClick_MatchMaking()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;
        // roomOptions.CustomRoomProperties
        // PhotonNetwork.JoinRandomRoom()
    }
    public const string ELO_RANGE = "Elo_range";
    public void CreateRandomRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;
        roomOptions.CustomRoomPropertiesForLobby = new string[] { ELO_RANGE };
        int eloRangeValue = (PlayFabStats.Instance.playerElo / 1000) * 1000;
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable { { ELO_RANGE, eloRangeValue } };
        PhotonNetwork.CreateRoom(null, roomOptions, null);
        // PhotonNetwork.CurrentRoom.IsOpen = false;
        // PhotonNetwork.CurrentRoom.IsVisible = false;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogErrorFormat("Room creation failed with error code {0} and error message {1}", returnCode, message);
    }
    public GameObject Timer;
    public GameObject hider;
    public override void OnCreatedRoom()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ELO_RANGE))
        {
            hider.SetActive(true);
            Timer.SetActive(true);
        }

    }
    public override void OnLeftRoom()
    {
        // if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ELO_RANGE))
        // {
        hider.SetActive(false);
        Timer.SetActive(false);
        // }

    }
    public override void OnJoinedRoom()
    {
        // joined a room successfully, CreateRoom leads here on success
        // if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ELO_RANGE))
        // {
        //     PhotonNetwork.CurrentRoom.IsVisible = false;
        // }

        Debug.Log("Create success");
    }
    #endregion

    #region  Match Making Join

    public void JoinRandomRoom()
    {
        int eloRangeValue = (PlayFabStats.Instance.playerElo / 1000) * 1000;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable { { ELO_RANGE, eloRangeValue } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 2);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRandomRoom();
        Debug.Log("join failed, create new room");
    }
    // public override void OnPlayerEnteredRoom(Player newPlayer)
    // {
    //     base.OnPlayerEnteredRoom(newPlayer);
    //     if()
    // }
    #endregion
}
