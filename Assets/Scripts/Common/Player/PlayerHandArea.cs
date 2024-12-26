using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerHandArea : MonoBehaviour
{
    public GameObject yourHandPrefab;
    public GameObject yourOPHandPrefab;
    public List<GameObject> cardholder;
    private void Init()
    {
        yourHandPrefab = transform.gameObject;
        yourOPHandPrefab = GameObject.Find("EnemyArea");

    }
    void Awake()
    {
        Init();
    }
}