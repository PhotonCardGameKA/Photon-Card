using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerListing : MonoBehaviour
{
    [SerializeField] private Text playerText;
    public Player Player { get; private set; }
    public void SetPlayerInfo(Player player)
    {
        Player = player;

        int result = -1;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result = (int)player.CustomProperties["RandomNumber"];
        }

        playerText.text = result.ToString() + "," + player.NickName;
    }
}