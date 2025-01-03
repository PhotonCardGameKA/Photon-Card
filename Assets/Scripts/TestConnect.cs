using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestConnect : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI connectStatus;
    private void Start()
    {
        Debug.Log("Connecting to server");
        #region Rate
        PhotonNetwork.SendRate = 40;
        #endregion
        PhotonNetwork.AutomaticallySyncScene = true;
        // PhotonNetwork.NickName = MasterManager.Instance.GameSettings.NickName;
        PhotonNetwork.NickName = PlayerPrefs.GetString("USERNAME");
        PhotonNetwork.GameVersion = MasterManager.Instance.GameSettings.GameVersion;
        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
        connectStatus.text = PhotonNetwork.NetworkClientState.ToString();
    }
    void Update()
    {
        connectStatus.text = PhotonNetwork.NetworkClientState.ToString();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnecting from server : " + cause.ToString());
    }
    public override void OnJoinedLobby()
    {

    }
}