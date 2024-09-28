using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        this.input.text = "room1";
    }
    private void Create()
    {
        string name = input.text;
        Debug.Log(transform.name + " : createRoom " + name);
        PhotonNetwork.CreateRoom(name);//trigger oncreateroom and onjoinroom
    }

    private void Join()
    {
        string name = input.text;
        Debug.Log(transform.name + " : JoinRoom " + name);
        PhotonNetwork.JoinRoom(name);

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("OncreateRoom");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }
    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed : " + message);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
