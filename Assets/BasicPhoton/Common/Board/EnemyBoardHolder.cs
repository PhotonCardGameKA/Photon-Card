using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyBoardCreatureHolder : MonoBehaviour
{
    [SerializeField] List<GameObject> creatureRef;
    [SerializeField] GameObject heroReference;
    void Awake()
    {
        this.GetListCreature();
    }
    public void GetListCreature()
    {
        foreach (Transform child in transform)
        {
            if (creatureRef.Contains(child.gameObject)) continue;
            creatureRef.Add(child.gameObject);
            if (child.gameObject.name == "PlayerIcon") heroReference = child.gameObject;
        }
    }
    public GameObject FindACreature(string name)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == name) return child.gameObject;
        }
        return null;
    }
    // void Start()
    // {
    //     this.GetListCreature();
    // }
}