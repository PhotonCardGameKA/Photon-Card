using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text playerText;
    public Player Player { get; private set; }


    public bool Ready = false;
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        SetPlayerText(player);

    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("RandomNumber"))
            {
                SetPlayerText(targetPlayer);
            }

        }
    }
    private void SetPlayerText(Player player)
    {
        int result = -1;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result = (int)player.CustomProperties["RandomNumber"];
        }

        playerText.text = result.ToString() + "," + player.NickName;
    }
}