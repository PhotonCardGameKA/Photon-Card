using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BoardCtrl : MonoBehaviourPunCallbacks
{
    [SerializeField] List<GameObject> creatureRef;
    [SerializeField] GameObject heroReference;

    void GetListCreature()
    {
        foreach (Transform child in transform)
        {
            if (creatureRef.Contains(child.gameObject)) continue;
            creatureRef.Add(child.gameObject);
            if (child.gameObject.name == "PlayerIcon") heroReference = child.gameObject;
        }
    }
    void Start()
    {
        this.GetListCreature();
    }
}