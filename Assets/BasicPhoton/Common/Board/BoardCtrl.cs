using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BoardCtrl : MonoBehaviourPunCallbacks
{
    [SerializeField] List<GameObject> creatureRef;
    [SerializeField] GameObject heroReference;
    public GameObject FindCreature(string name)
    {
        foreach (GameObject obj in creatureRef)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }

    void GetListCreature()
    {
        foreach (Transform child in transform)
        {
            if (creatureRef.Contains(child.gameObject)) continue;
            if (child.tag == "Bullet") continue;
            creatureRef.Add(child.gameObject);
            if (child.gameObject.name == "PlayerIcon") heroReference = child.gameObject;
        }
    }
    void RemoveEmpty()
    {
        foreach (GameObject child in creatureRef)
        {
            if (child == null) creatureRef.Remove(child);
        }
    }
    public void UpdateListCreature()
    {
        RemoveEmpty();
        GetListCreature();
    }
    void Start()
    {
        this.GetListCreature();
    }
}