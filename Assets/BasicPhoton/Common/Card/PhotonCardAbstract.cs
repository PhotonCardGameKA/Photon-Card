using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public abstract class PhotonCardAbstract : MonoBehaviour
{
    [SerializeField] private PhotonCardCtrl photonCardCtrl;
    void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        this.LoadPhotonCardCtrl();
    }
    protected virtual void LoadPhotonCardCtrl()
    {
        if (this.photonCardCtrl != null) return;
        this.photonCardCtrl = GetComponentInParent<PhotonCardCtrl>();
    }

}