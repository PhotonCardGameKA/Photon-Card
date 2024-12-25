using System.Collections.Generic;
using UnityEngine;

public class EnemyCardInHand : MonoBehaviour
{
    public List<GameObject> cardHolder;
    public int maxCardInHand = 7;
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
        cardHolder[0].SetActive(false);
        UpdateList();
    }
}