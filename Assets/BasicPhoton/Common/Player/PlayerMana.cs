using Photon.Pun;
using UnityEditor;

using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int currentMana = 1;
    public int unlockedMana = 1;
    public int maxMana = 10;
    public PlayerController playerController;
    public GameObject manaPipHolder;
    public GameObject pipPrefab;
    public void AddPip()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            int childCount = 0;


            foreach (Transform child in manaPipHolder.transform)
            {
                if (childCount < 2)
                {
                    child.gameObject.SetActive(false);
                    childCount++;
                }
            }
        }
    }
    public void UsePip()
    {
        if (this.currentMana < maxMana) currentMana += 1;
        else currentMana = maxMana;


        playerController.playerManaUI.SetUI(currentMana, unlockedMana);
    }
    private void Awake()
    {
        if (this.playerController != null) return;
        this.playerController = GetComponentInParent<PlayerController>();
        AddPip();
    }
    public void UnlockMana(int amount)
    {
        if (this.unlockedMana + amount >= maxMana) this.unlockedMana = maxMana;
        else this.unlockedMana += amount;
    }
    public void RefreshMana(int amount)
    {
        if (this.currentMana + amount >= this.unlockedMana) this.currentMana = unlockedMana;
        else this.currentMana += amount;
    }
    public void RefreshAtYourTurn()
    {
        // Debug.LogError("Refresh");
        UnlockMana(1);
        RefreshMana(unlockedMana);
        this.playerController.playerManaUI.SetUI(this.currentMana, this.unlockedMana);
    }
    public void UseMana(int cost)
    {
        if (this.currentMana - cost >= 0)
        {
            this.currentMana -= cost;
            this.playerController.playerManaUI.SetUI(this.currentMana, this.unlockedMana);
        }

        //handle not enough mana
        else Debug.LogError("ko du mana");
    }
    public bool IsValidCard(int cost)
    {
        return cost <= currentMana;
    }
}