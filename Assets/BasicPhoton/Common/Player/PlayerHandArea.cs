using Photon.Pun;
using UnityEngine;

public class PlayerHandArea : MonoBehaviourPunCallbacks
{
    public GameObject yourHandPrefab;
    public GameObject yourOPHandPrefab;
    private Transform yourHand;
    public Transform PlayerArea => yourHand;
    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            yourHand = yourHandPrefab.transform;
        }
        else
        {
            yourHand = yourOPHandPrefab.transform;
        }
    }

}