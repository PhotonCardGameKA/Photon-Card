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
        return newCreature;
    }
}
