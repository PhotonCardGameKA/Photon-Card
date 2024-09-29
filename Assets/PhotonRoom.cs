using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public static PhotonRoom instance;
    public TMP_InputField input;
    public Transform roomContent;
    public UIRoomProfile roomPrefab;
    public List<RoomInfo> updatedRooms;
    public List<RoomProfile> rooms = new List<RoomProfile>();

    private void Start()
    {
        this.input.text = "Room1";
    }
    void Awake()
    {
        if (PhotonRoom.instance != null) return;
        PhotonRoom.instance = this;
    }

    public virtual void Create()
    {
        string name = input.text;
        Debug.Log(transform.name + ": Create Room " + name);
        PhotonNetwork.CreateRoom(name);
    }

    public virtual void Join()
    {
        string name = input.text;
        Debug.Log(transform.name + ": Join Room " + name);
        PhotonNetwork.JoinRoom(name);
    }
    public virtual void Leave()
    {
        Debug.Log(transform.name + ": LeaveRoom");
        PhotonNetwork.LeaveRoom();
    }

    public virtual void StartGame()
    {
        Debug.Log(transform.name + " : StartGame");
        //if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel("2_PhotonGame");
        //else Debug.LogWarning("You are not Master Client");
        PhotonNetwork.LoadLevel("2_PhotonGame");
    }






    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        this.StartGame();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed: " + message);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("OnRoomListUpdate");
        this.updatedRooms = roomList;

        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList) this.RoomRemove(roomInfo);//roominfo return true if a room removed
            else this.RoomAdd(roomInfo);
        }

        this.UpdateRoomProfileUI();
    }//return room updated (add, remove)

    protected virtual void RoomAdd(RoomInfo roomInfo)
    {
        RoomProfile roomProfile;

        roomProfile = this.RoomByName(roomInfo.Name);//avoid duplicate room
        if (roomProfile != null) return;

        roomProfile = new RoomProfile
        {
            name = roomInfo.Name

        };
        Debug.Log(roomInfo.Name);
        this.rooms.Add(roomProfile);

    }

    protected virtual void UpdateRoomProfileUI()
    {
        Debug.Log("st");
        foreach (Transform child in this.roomContent)
        {
            Destroy(child.gameObject);
        }

        foreach (RoomProfile roomProfile in this.rooms)
        {
            UIRoomProfile uiRoomProfile = Instantiate(this.roomPrefab);
            uiRoomProfile.SetRoomProfile(roomProfile);
            uiRoomProfile.transform.SetParent(this.roomContent);
        }
        Debug.Log("ST2");
    }

    protected virtual void RoomRemove(RoomInfo roomInfo)
    {
        RoomProfile roomProfile = this.RoomByName(roomInfo.Name);
        if (roomProfile == null) return;
        this.rooms.Remove(roomProfile);
    }

    protected virtual RoomProfile RoomByName(string name)
    {
        foreach (RoomProfile roomProfile in this.rooms)
        {
            if (roomProfile.name == name) return roomProfile;
        }
        return null;
    }
}