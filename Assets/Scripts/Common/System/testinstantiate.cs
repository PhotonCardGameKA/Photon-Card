using UnityEngine;


public class testinstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    int boardId;
    private void OnEnable()
    {
        float rd = Random.Range(0f, 10f);
        Vector3 pos = new Vector3(rd, rd, rd) + transform.position;
        GameObject player = MasterManager.NetworkInstantiate(_prefab, pos, transform.rotation);



    }

}