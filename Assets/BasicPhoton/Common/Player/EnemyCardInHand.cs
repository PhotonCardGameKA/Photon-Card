using System.Collections.Generic;
using UnityEngine;

public class EnemyCardInHand : MonoBehaviour
{
    public List<GameObject> cardHolder;
    public int maxCardInHand = 7;
    [SerializeField] PhotonCardSpawner photonCardSpawner;

    private void Awake()
    {
        this.LoadCardSpawner();
    }
    void LoadCardSpawner()
    {
        if (photonCardSpawner != null) return;
        photonCardSpawner = transform.GetComponent<PhotonCardSpawner>();
    }
    public void UpdateList()
    {
        cardHolder.Clear();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf) cardHolder.Add(child.gameObject);
        }
        if (cardHolder.Count > maxCardInHand)
        {
            RemoveOneCard();
        }
    }
    public void RemoveOneCard()
    {
        GameObject tmp = cardHolder[0];
        tmp.SetActive(false);
        photonCardSpawner.ReturnToPool(tmp);
        UpdateList();
    }
}