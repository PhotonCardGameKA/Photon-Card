using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class MultiplayerBoard : MonoBehaviour
{
    private PhotonView photonView;
    void Awake()
    {
        this.photonView = GetComponent<PhotonView>();
    }
    // Vector2 coords;
    // public void SelectMove()
    // {
    //     photonView.RPC(nameof(RPC_Unselected), RpcTarget.AllBuffered, new object[] { coords });
    // }

    // [PunRPC]
    // private object RPC_Unselected(Vector2 coords)
    // {
    //     Vector2 intCroods = new Vector2(Mathf.RoundToInt(coords.x), Mathf.RoundToInt(coords.y));

    // }
}
