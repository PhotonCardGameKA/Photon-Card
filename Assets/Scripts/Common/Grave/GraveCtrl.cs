using System.Collections.Generic;
using UnityEngine;

public class GraveCtrl : MonoBehaviour
{
    public List<GameObject> cardUsed;
    public GameObject cardHolder;
    public void AddCardToGrave(GameObject card)
    {
        cardUsed.Add(card);
        card.transform.SetParent(cardHolder.transform);
        card.gameObject.SetActive(false);
        UpdateList();
    }
    public void UpdateList()
    {
        cardUsed.Clear();
        foreach (Transform child in cardHolder.transform)
        {
            cardUsed.Add(child.gameObject);
        }
    }
}