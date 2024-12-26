using TMPro;
using UnityEngine;

public class PlayerManaUI : MonoBehaviour
{
    public TextMeshProUGUI currentManaText;
    public TextMeshProUGUI unlockedManaText;
    public PlayerController playerController;
    private void Awake()
    {
        if (this.playerController != null) return;
        this.playerController = GetComponentInParent<PlayerController>();
    }
    public void SetUI(int currentMana, int unlockedMana)
    {
        this.currentManaText.text = currentMana.ToString();
        this.unlockedManaText.text = unlockedMana.ToString();
    }
}