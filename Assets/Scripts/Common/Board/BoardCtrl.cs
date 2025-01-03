using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BoardCtrl : MonoBehaviourPunCallbacks
{
    [SerializeField] public List<GameObject> creatureRef;
    [SerializeField] GameObject heroReference;
    [SerializeField] private ReceiveDamageEventHandle receiveDamageEventHandle;
    public GameObject opBoard;
    public SystemTurnManager turnManager;
    public void UpdateStateCreature(bool value)
    {
        foreach (GameObject creature in creatureRef)
        {
            creature.GetComponentInChildren<ArrowDragDrop>().canDrag = value;
        }
    }
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
        this.turnManager = GameObject.Find("EndTurnButton").GetComponent<SystemTurnManager>();
        if (this.receiveDamageEventHandle != null) return;
        this.receiveDamageEventHandle = GetComponent<ReceiveDamageEventHandle>();
    }
    void Start()
    {
        this.UpdateListCreature();
    }
}