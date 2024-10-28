using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RoomListing : MonoBehaviour
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
}