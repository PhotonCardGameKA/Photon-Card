using System.Collections.Generic;
using UnityEngine;

public class EnemyCardInHand : MonoBehaviour
{
    public List<GameObject> cardHolder;
    public void UpdateList()
    {
        cardHolder.Clear();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf) cardHolder.Add(child.gameObject);
        }
    }
    public void RemoveOneCard()
    {
        cardHolder[0].SetActive(false);
        UpdateList();
    }
}