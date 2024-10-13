using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject hand;
    public GameObject it;

    void Update()
    {
        hand = GameObject.Find("Hand");

        it.transform.SetParent(hand.transform);
        it.transform.localScale = Vector3.one;
        //it.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, 0);
        //it.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
