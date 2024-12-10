using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Unity.Mathematics;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField] private GameSettings gameSettings;

    public GameSettings GameSettings => Instance.gameSettings;
    [SerializeField]
    private List<NetworkPrefab> _networkPrefabs = new List<NetworkPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, quaternion rotation)
    {
        foreach (NetworkPrefab networkPrefab in Instance._networkPrefabs)
        {
            if (networkPrefab.Prefab == obj)
            {
                if (networkPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefab.Path, position, rotation);
                    // Debug.LogError(networkPrefab.Path);
                    // result.transform.SetParent(parent, false);
                    return result;
                }
                else
                {
                    Debug.LogError("path is empty", networkPrefab.Prefab);
                    return null;
                }
            }
        }
        return null;
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkPrefabs()
    {
#if UNITY_EDITOR

        Instance._networkPrefabs.Clear();
        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance._networkPrefabs.Add(new NetworkPrefab(results[i], path));
            }
        }

        for (int i = 0; i < Instance._networkPrefabs.Count; i++)
        {
            UnityEngine.Debug.Log(Instance._networkPrefabs[i].Prefab.name + "," + Instance._networkPrefabs[i].Path);
        }
#endif
    }
}
