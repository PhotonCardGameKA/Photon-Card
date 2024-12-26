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

        CreatureProp prop = newCreature.GetComponentInChildren<CreatureProp>();
        prop.SetCardProp(creatureProp);
        prop.SetProp();
        newCreature.name = creatureProp.objectName;
        return newCreature;
    }
    public GameObject SpawnAtEnemySide()
    {
        return null;
    }
}
