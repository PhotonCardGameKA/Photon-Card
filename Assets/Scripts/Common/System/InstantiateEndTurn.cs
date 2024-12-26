using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


public class InstantiateEndTurn : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] public List<int> playerRef;

    int boardId;
    private void Awake()
    {
        // PhotonView boardPv = transform.GetComponentInParent<PhotonView>();
        // boardId = boardPv.ViewID;


        GameObject player = MasterManager.NetworkInstantiate(_prefab, _prefab.transform.position, transform.rotation);
        if (player == null) Debug.LogError("ko co player");
        player.transform.SetParent(transform.parent, false);
        player.name = _prefab.name + PhotonNetwork.LocalPlayer.NickName;
        PhotonView pv = player.GetComponent<PhotonView>();

        photonView.RPC(nameof(this.RPC_AddPVRef), RpcTarget.AllBuffered, pv.ViewID);



    }

    [PunRPC]
    void RPC_AddPVRef(int pvID)
    {
        if (!playerRef.Contains(pvID))
        {
            playerRef.Add(pvID);
        }
    }


}