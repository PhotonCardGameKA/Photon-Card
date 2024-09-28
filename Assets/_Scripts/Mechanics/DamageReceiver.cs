using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : AnMonoBehaviour
{
    [SerializeField] protected int currentHp = 30;
    [SerializeField] protected int maxHp = 30;
    [SerializeField] protected int defaultMaxHp = 30;
    [SerializeField] protected bool isDead = false;
    public int CurrentHp => currentHp;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.currentHp = this.maxHp;
        this.isDead = false;
        this.maxHp = this.defaultMaxHp;
    }
    public virtual void Deduct(int damage)
    {
        this.currentHp -= damage;
        this.CheckIsDead();

    }
    protected virtual bool IsDead()
    {
        return this.currentHp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected abstract void OnDead();//do sth like fx

}
