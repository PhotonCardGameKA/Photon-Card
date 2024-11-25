using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonCardSpawner : MonoBehaviourPun//spam in enemy side
{
    public GameObject cardPrefab;
    void Awake()
    {
        if (cardPrefab == null) Debug.LogError("Lack of card prefab");
    }
    public void EnemyCardUISide()
    {
        GameObject card = Instantiate(cardPrefab);
        card.GetComponent<PhotonCardUI>().UnHideCardBack();
        card.transform.SetParent(transform);
    }
}
