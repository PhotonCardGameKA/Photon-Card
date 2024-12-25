using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform _content;
    [SerializeField] private PlayerListing _playerListing;
    private List<PlayerListing> _listing = new List<PlayerListing>();
    private RoomCanvases _roomCanvases;
    [SerializeField] private Text _readyUpText;
    private bool _ready = false;
    PhotonView _photonView;

    private void Awake()
    {

        GetCurrentRoomPlayer();
        this._photonView = GetComponent<PhotonView>();
    }
    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayer();
        SetReadyUp(false);
    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listing.Count; i++)
        {
            Destroy(_listing[i].gameObject);
        }
        _listing.Clear();
    }
    private void SetReadyUp(bool state)
    {
        _ready = state;
        if (_ready) _readyUpText.text = "Ready";
        else _readyUpText.text = "Not Ready";
    }
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }
    // public override void OnLeftRoom()
    // {
    //     _content.DestroyChildren();
    // }
    private void GetCurrentRoomPlayer()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player player)
    {
        int index = _listing.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listing[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListing, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listing.Add(listing);
            }
        }

    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
        _roomCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }



    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listing.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listing[index].gameObject);
            _listing.RemoveAt(index);
        }
    }
    public void OnClick_StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            AnNotification.Instance.CustomMessage("YOU ARE NOT MASTERCLIENT");
            return;
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            AnNotification.Instance.CustomMessage("NOT ENOUGH PLAYERS IN THE ROOM");
            return;
        }
        if (PhotonNetwork.IsMasterClient)
        {

            for (int i = 0; i < _listing.Count; i++)
            {
                if (_listing[i].Player == PhotonNetwork.LocalPlayer) continue;
                if (!_listing[i].Ready)
                {
                    AnNotification.Instance.CustomMessage("WAITING FOR OTHER PLAYERS TO GET READY");
                    return;
                }
            }
            ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
            _myCustomProperties["OpponentName"] = PhotonNetwork.PlayerListOthers.FirstOrDefault().NickName;
            PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }//hide room while game starting 
    }
    public void OnClick_ReadyUp()
    {

        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!_ready);
            _photonView.RPC("RPC_ChangeReadyState", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer, _ready);
        }
        else
        {
            AnNotification.Instance.CustomMessage("YOU ARE THE HOST AND DON'T NEED TO READY UP");
            return;
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = _listing.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listing[index].Ready = ready;
        }
    }

}