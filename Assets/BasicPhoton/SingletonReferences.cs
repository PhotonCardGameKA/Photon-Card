using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonReferences : MonoBehaviour
{
    [SerializeField] private MasterManager masterManager;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
