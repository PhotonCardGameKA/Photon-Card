using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _roomName;
    private RoomCanvases roomCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }
    [SerializeField] int maxRoomAllow = 1;
    int CurrentRoomCount;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        CurrentRoomCount = roomList.Count;
    }
    public void OnClick_CreateRoom()
    {
        SoundManager.Instance.PlaySound("UIClick");
        if (!PhotonNetwork.IsConnected)
        {
            AnNotification.Instance.CustomMessage("NOT CONNECTED TO SERVER");
            return;
        }
        // PhotonNetwork.r
        if (CurrentRoomCount >= maxRoomAllow)
        {
            AnNotification.Instance.CustomMessage("CANNOT CREATE MORE ROOMS, PLEASE WAIT FOR OTHERS PLAYERS TO LEAVE");
            return;
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;
        if (string.IsNullOrEmpty(_roomName.text))
        {
            AnNotification.Instance.CustomMessage("YOU CAN'T CREATE A ROOM WITH AN EMPTY NAME");
            return;
        }
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, roomOptions, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("created room successfull", this);
        roomCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        AnNotification.Instance.CustomMessage("CREATE ROOM FAILED");
        Debug.Log("created room failed" + message, this);
    }
}
