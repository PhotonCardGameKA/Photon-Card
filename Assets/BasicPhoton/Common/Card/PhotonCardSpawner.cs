using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonCardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    void Awake()
    {
        if (cardPrefab == null) Debug.LogError("Lack of card prefab");
    }
    public void InstantiateCard()
    {

    }
}
