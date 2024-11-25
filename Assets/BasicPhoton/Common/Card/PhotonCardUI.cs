using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PhotonCardUI : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject cardBack;
    public GameObject selectedVisual;
    public GameObject hpImage;
    public GameObject atkImage;
    [SerializeField] private PhotonCardCtrl photonCardCtrl;
    void Awake()
    {
        if (this.photonCardCtrl != null) return;
        this.photonCardCtrl = GetComponentInParent<PhotonCardCtrl>();
    }

    [PunRPC]
    public void RPC_ShowCardBack()
    {
        if (photonView.IsMine)
        {
            cardBack.SetActive(false);
        }
        else cardBack.SetActive(true);

    }
    public void UnHideCardBack()
    {
        this.cardBack.SetActive(true);
    }
    public void ShowCardBack()
    {
        photonView.RPC(nameof(this.RPC_ShowCardBack), RpcTarget.All);
    }
    public void ToggleSelect(bool selected)
    {
        selectedVisual.SetActive(selected);
    }
    [PunRPC]
    public void RPC_UpdateHealthImage(int damage)
    {

    }
    public void UpdateHealthImage(int damage)
    {
        photonView.RPC(nameof(this.RPC_UpdateHealthImage), RpcTarget.All, damage);
    }

}