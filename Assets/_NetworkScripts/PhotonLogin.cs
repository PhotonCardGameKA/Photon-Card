using UnityEngine;
using Photon.Pun;
using TMPro;

public class PhotonLogin : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputUsername;
    public string nickName;

    void Start()
    {
        this.nickName = "an";
        this.inputUsername.text = this.nickName;
    }

    public virtual void OnChangeName()
    {
        this.nickName = this.inputUsername.text;
    }

    public virtual void Login()
    {
        string name = this.nickName;
        Debug.Log(transform.name + ": Login " + name);

        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = name;
        PhotonNetwork.NickName = name;

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }
}
