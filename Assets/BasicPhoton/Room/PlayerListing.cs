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
        playerText.text = player.NickName;
    }
}