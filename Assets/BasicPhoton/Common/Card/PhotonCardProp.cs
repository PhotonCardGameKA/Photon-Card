using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonCardProp : MonoBehaviour
{
    [SerializeField] private PhotonCardCtrl photonCardCtrl;

    public int currentHp;
    public int maxHp;
    public int currentAtk;
    public int maxAtk;
    public bool usedThisTurn;
    void Awake()
    {
        if (this.photonCardCtrl != null) return;
        this.photonCardCtrl = GetComponentInParent<PhotonCardCtrl>();
    }
    public bool CanSelect()
    {
        return !usedThisTurn;
    }
    public bool CanAttack()
    {
        if (!this.CanSelect()) return false;
        return true;
    }

}
