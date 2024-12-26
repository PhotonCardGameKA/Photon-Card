using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonCardSpawner : MonoBehaviourPun//spam in enemy side
{
    [SerializeField] private EnemyCardInHand enemyCardInHand;
    public GameObject cardPrefab;
    void Awake()
    {
        if (cardPrefab == null) Debug.LogError("Lack of card prefab");
        enemyCardInHand = GetComponent<EnemyCardInHand>();
    }
    public void EnemyCardUISide()
    {
        SoundManager.Instance.PlaySound("DrawCard");
        GameObject card = Instantiate(cardPrefab, transform);
        card.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        card.GetComponentInChildren<PhotonCardUI>().UnHideCardBack();
        Destroy(card.GetComponent<DragDrop>());
        enemyCardInHand.UpdateList();
    }
}
