using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    [SerializeField] public PhotonView P1;
    [SerializeField] public PhotonView P2;
    [SerializeField] private PlayerManager p1Manager;
    [SerializeField] private PlayerManager p2Manager;
    public GameObject playerInstantiateObj;
    public PhotonCardSpawner photonCardSpawner;
    [SerializeField] public List<int> playerRef;
    public PlayerRename playerRename;
    public PlayerController yourPlayer;


    public GameObject settingScreen;
    public GameObject confirmLeaveGame;


    public GameObject preventerCreatureAttack;
    void Awake()
    {
        // if (playerRename == null) playerRename = GetComponent<PlayerRename>();
        if (Instance != null)
        {
            Debug.LogError("Duplicate singleton");
        }
        Instance = this;
        LoadPlayerInstantiate();
        Invoke(nameof(this.AddPlayerRef), 2f);
        LoadPhotonCardSpawner();

        //do some animation
    }
    void AddPlayerRef()
    {
        InstantiateEndTurn instantiateEndTurn = playerInstantiateObj.GetComponent<InstantiateEndTurn>();
        playerRef = instantiateEndTurn.playerRef;

        P1 = PhotonView.Find(instantiateEndTurn.playerRef[0]);
        p1Manager = P1.gameObject.GetComponent<PlayerManager>();
        P2 = PhotonView.Find(instantiateEndTurn.playerRef[1]);
        p2Manager = P2.gameObject.GetComponent<PlayerManager>();
        playerRename.Rename();
        // yourPlayer = playerRename.player.GetComponent<PlayerController>();
        WaitForPlayerController();
    }
    void WaitForPlayerController()
    {
        int yourPv;
        if (P1.IsMine) yourPv = P1.ViewID;
        else yourPv = P2.ViewID;
        GameObject playerObject = PhotonView.Find(yourPv).gameObject;
        this.yourPlayer = playerObject.GetComponent<PlayerController>();
    }
    void LoadPlayerInstantiate()
    {
        this.playerInstantiateObj = GameObject.Find("PlayerInstantiate");
    }
    void LoadPhotonCardSpawner()
    {
        this.photonCardSpawner = GameObject.Find("EnemyArea").GetComponent<PhotonCardSpawner>();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        SoundManager.Instance.PlaySound("UIClick");
        PhotonNetwork.LeaveRoom();
    }
    //scale for more than 2 player
    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            return;
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    // [PunRPC]
    public void SyncTurn(bool isMyTurn)
    {
        if (isMyTurn)
        {
            yourPlayer.playerMana.RefreshAtYourTurn();
            if (P1.IsMine)
            {
                p1Manager.playerController.PlayerDraw.DrawLocal();
            }
            else
            {
                p2Manager.playerController.PlayerDraw.DrawLocal();
            }
        }
        else
        if (!isMyTurn)
        { //22/12

            //22/12
            photonCardSpawner.EnemyCardUISide();
        }
    }
    public void DrawAtStartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < 3; i++)
            {
                photonView.RPC(nameof(this.DrawNetwork), RpcTarget.All, P1.ViewID);
                photonView.RPC(nameof(this.DrawNetwork), RpcTarget.All, P2.ViewID);
            }
            if (P1.IsMine) photonView.RPC(nameof(this.DrawNetwork), RpcTarget.All, P1.ViewID);
            else photonView.RPC(nameof(this.DrawNetwork), RpcTarget.All, P2.ViewID);
        }//chu phong di truoc thi duoc them 1 la


    }
    bool isMute = false;
    public void OnClickMute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
    [PunRPC]
    public void DrawNetwork(int pvId)
    {
        // SoundManager.Instance.PlaySound("DrawCard");
        PhotonView pvTemp = PhotonView.Find(pvId);
        if (pvTemp.IsMine)
        {
            PlayerManager pmTemp = pvTemp.gameObject.GetComponent<PlayerManager>();
            pmTemp.playerController.PlayerDraw.DrawLocal();
        }
        else
        {
            photonCardSpawner.EnemyCardUISide();
        }
    }
    public void OnClickTurnOnSetting()
    {
        SoundManager.Instance.PlaySound("UIClick");
        settingScreen.SetActive(true);
    }
    public void OnClickTurnOffSetting()
    {
        SoundManager.Instance.PlaySound("UIClick");
        settingScreen.SetActive(false);
    }
    public void OnClickTurnOnLeaveGame()
    {
        SoundManager.Instance.PlaySound("UIClick");
        confirmLeaveGame.SetActive(true);
    }
    public void OnClickTurnOffLeaveGame()
    {
        SoundManager.Instance.PlaySound("UIClick");
        confirmLeaveGame.SetActive(false);
    }
    public void ActivePreventerCreature(bool state)
    {
        preventerCreatureAttack.SetActive(state);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        if (WinCondition.Instance.isLose && !WinCondition.Instance.isWin) return;
        AnNotification.Instance.CustomMessage("Your OP Disconnected");
        WinCondition.Instance.WinProcess();
    }
}
