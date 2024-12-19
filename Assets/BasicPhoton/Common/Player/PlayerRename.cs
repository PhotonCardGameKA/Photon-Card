using Photon.Pun;
using UnityEngine;

public class PlayerRename : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    public void Rename()
    {
        // Debug.LogError("1");
        if (GameManager.Instance.P1.IsMine)
        {
            player.name = "PlayerIcon" + GameManager.Instance.P1.ViewID.ToString();
            enemy.name = "PlayerIcon" + GameManager.Instance.P2.ViewID.ToString();
            Debug.LogError(player.name + ":" + enemy.name);
        }
        else
        {
            player.name = "PlayerIcon" + GameManager.Instance.P2.ViewID.ToString();
            enemy.name = "PlayerIcon" + GameManager.Instance.P1.ViewID.ToString();
            Debug.LogError(player.name + ":" + enemy.name);
        }
    }

}