using UnityEngine;
using UnityEngine.Scripting;

public class InstantiateEndTurn : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private void Awake()
    {
        MasterManager.NetworkInstantiate(_prefab, _prefab.transform.position, transform.rotation, transform);


    }

}