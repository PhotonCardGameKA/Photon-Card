using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMana : ManaSystem
{
    [SerializeField] protected TextMeshProUGUI manaUI;
    protected void Awake()
    {
        this.LoadManaUI();
        this.UpdateUI();
    }
    protected virtual void LoadManaUI()
    {
        if (this.manaUI != null) return;
        this.manaUI = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + " LoadManaUI : ", gameObject);
    }
    public void UpdateUI()
    {
        this.manaUI.text = this.currentMana + "  /  " + this.playerMaxMana.ToString();
    }
    public override void UseMana(int cost)
    {
        base.UseMana(cost);
        this.UpdateUI();
    }
}