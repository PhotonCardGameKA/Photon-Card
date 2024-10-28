using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomCanvases _roomCanvases;
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomCanvases.CurrentRoomCanvas.Hide();
    }
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }
}
