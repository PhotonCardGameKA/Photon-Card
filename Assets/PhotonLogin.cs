using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PhotonLogin : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputUsername;
    void Start()
    {
        this.inputUsername.text = "an";
    }
    public virtual void Login()
    {
        string name = inputUsername.text;
        Debug.Log(transform.name + " : Login " + name);
        PhotonNetwork.LocalPlayer.NickName = name;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
    }
}
