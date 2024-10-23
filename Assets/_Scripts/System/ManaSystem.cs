using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    protected int maxMana = 10;
    [SerializeField] public int playerMaxMana = 1;
    [SerializeField] public int currentMana = 1;
    public virtual void AddMana(int num)
    {
        if (this.playerMaxMana + num >= maxMana)
        {
            this.playerMaxMana = maxMana;
        }
        else this.playerMaxMana += num;
    }
    public virtual void UseMana(int cost)
    {
        if (this.currentMana - cost >= 0)
        {
            this.currentMana -= cost;
        }
    }
    public virtual void ResetMana()
    {
        this.currentMana = this.playerMaxMana;
    }
}
