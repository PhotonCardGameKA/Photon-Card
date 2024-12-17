using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject creaturePrefab;
    public GameObject SpawnWithProp(PhotonCardProp creatureProp)
    {
        GameObject newCreature = Instantiate(creaturePrefab);
        string uniqueName = creatureProp.pvOwnerId.ToString() + "_" + (System.DateTime.Now.Ticks % 10000).ToString();
        CreatureProp prop = newCreature.GetComponentInChildren<CreatureProp>();
        prop.SetCardProp(creatureProp);
        prop.SetProp();
        newCreature.name = uniqueName;
        return newCreature;
    }
    public GameObject SpawnAtEnemySide()
    {
        return null;
    }
}
