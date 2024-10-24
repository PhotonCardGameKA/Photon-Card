using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDrawCard : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject playerArea;
    public GameObject enemyArea;
    public void OnClick()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(card1, new Vector2(0, 0), Quaternion.identity);
            playerCard.transform.SetParent(playerArea.transform, false);
        }

    }
}
