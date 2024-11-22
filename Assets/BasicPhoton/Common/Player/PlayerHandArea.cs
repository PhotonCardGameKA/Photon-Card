using Photon.Pun;
using UnityEngine;

public class PlayerHandArea : MonoBehaviourPunCallbacks
{
    public GameObject yourHandPrefab;
    public GameObject yourOPHandPrefab;
    [SerializeField] private Transform yourHand;
    public Transform PlayerArea => yourHand;
    private void Init()
    {
        if (photonView.IsMine)
        {
            yourHand = yourHandPrefab.transform;
        }
        else
        {
            yourHand = yourOPHandPrefab.transform;
        }
    }
    void Awake()
    {
        Init();
    }
    void Reset()
    {
        Init();
    }
}