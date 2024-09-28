using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : AnMonoBehaviour
{
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    public PlayerDamageReceiver _PlayerDamageReceiver => playerDamageReceiver;
    [SerializeField] protected PlayerDamageSender playerDamageSender;
    public PlayerDamageSender _PlayerDamageSender => playerDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerDamageReceiver();
        this.LoadPlayerDamageSender();
    }
    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = transform.GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + " : LoadPlayerDamageReceiver", gameObject);
    }
    protected virtual void LoadPlayerDamageSender()
    {
        if (this.playerDamageSender != null) return;
        this.playerDamageSender = transform.GetComponentInChildren<PlayerDamageSender>();
        Debug.Log(transform.name + " : LoadPlayerDamageSender", gameObject);
    }
}
