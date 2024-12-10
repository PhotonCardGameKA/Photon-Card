using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    [SerializeField] private PhotonView P1;
    [SerializeField] private PhotonView P2;
    [SerializeField] private PlayerManager p1Manager;
    [SerializeField] private PlayerManager p2Manager;
    public GameObject playerInstantiateObj;
    public PhotonCardSpawner photonCardSpawner;
    [SerializeField] public List<int> playerRef;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Duplicate singleton");
        }
        Instance = this;
        LoadPlayerInstantiate();
        Invoke(nameof(this.AddPlayerRef), 5f);
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
        {
            photonCardSpawner.EnemyCardUISide();
        }
    }
}
