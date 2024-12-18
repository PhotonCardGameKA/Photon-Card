using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BoardCtrl : MonoBehaviourPunCallbacks
{
    [SerializeField] List<GameObject> creatureRef;
    [SerializeField] GameObject heroReference;
    [SerializeField] private ReceiveDamageEventHandle receiveDamageEventHandle;
    public GameObject opBoard;
    public void UpdateListCreature()
    {
        creatureRef.Clear();
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("CreaturePlayer") && child.gameObject.activeSelf)
            {
                creatureRef.Add(child.gameObject);
            }
            if (child.gameObject.name == "PlayerIcon") heroReference = child.gameObject;
        }
    }
    public GameObject FindAllyCreature(string name)
    {
        foreach (GameObject child in creatureRef)
        {
            if (child.name == name) return child;
        }
        return null;
    }
    void Awake()
    {
        opBoard = GameObject.Find("DropZoneE");
        if (this.receiveDamageEventHandle != null) return;
        this.receiveDamageEventHandle = GetComponent<ReceiveDamageEventHandle>();
    }
    void Start()
    {
        this.UpdateListCreature();
    }
}