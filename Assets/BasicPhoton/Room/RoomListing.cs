using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RoomListing : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text roomText;
    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        // Debug.Log(roomInfo.MaxPlayers + "" + roomInfo.Name);
        roomText.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }
    public void Onclick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        AnNotification.Instance.CustomMessage("ROOM IS FULL");
    }
}