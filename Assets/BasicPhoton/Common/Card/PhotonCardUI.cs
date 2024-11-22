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

    private void ShowCardBack(bool state)
    {
        cardBack.SetActive(state);
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