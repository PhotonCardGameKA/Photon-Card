using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject creaturePrefab;
    public BoardCtrl boardCtrl;
    private void Awake()
    {
        if (this.boardCtrl != null) return;
        this.boardCtrl = GetComponentInChildren<BoardCtrl>();
    }
    public GameObject SpawnWithProp(PhotonCardProp creatureProp)
    {
        GameObject newCreature = Instantiate(creaturePrefab);
        newCreature.name = DateTime.Now.ToString();
        CreatureProp prop = newCreature.GetComponentInChildren<CreatureProp>();
        prop.SetCardProp(creatureProp);
        prop.SetProp();
        boardCtrl.UpdateListCreature();
        return newCreature;
    }
    public GameObject SpawnAtEnemySide()
    {
        return null;
    }
}
