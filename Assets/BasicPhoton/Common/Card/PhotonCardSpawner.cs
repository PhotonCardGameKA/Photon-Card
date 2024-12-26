using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonCardSpawner : MonoBehaviourPun//spam in enemy side
{
    [SerializeField] private EnemyCardInHand enemyCardInHand;
    public GameObject cardPrefab;
    public List<GameObject> poolCard;
    public GameObject poolHolder;
    void Awake()
    {
        if (cardPrefab == null) Debug.LogError("Lack of card prefab");
        enemyCardInHand = GetComponent<EnemyCardInHand>();
    }
    public void EnemyCardUISide()
    {
        SoundManager.Instance.PlaySound("DrawCard");
        GameObject card = TakeFromPool();
        if (card == null)
        {
            card = Instantiate(cardPrefab, transform);
        }

        card.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        card.GetComponentInChildren<PhotonCardUI>().UnHideCardBack();
        Destroy(card.GetComponent<DragDrop>());
        enemyCardInHand.UpdateList();
    }
    public void ReturnToPool(GameObject cardToPool)
    {
        cardToPool.transform.SetParent(poolHolder.transform);
        poolCard.Add(cardToPool);
        cardToPool.SetActive(false);
    }
    public GameObject TakeFromPool()
    {
        if (poolCard.Count > 0)
        {
            GameObject tmpCard = poolCard[0];
            tmpCard.SetActive(true);
            tmpCard.transform.SetParent(transform);
            poolCard.Remove(tmpCard);
            return tmpCard;
        }

        return null;
    }
}
