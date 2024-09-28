using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardAbstract : AnMonoBehaviour
{
    [Header("card Abstract")]
    [SerializeField] protected CardCtrl cardCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardCtrl();
    }
    protected virtual void LoadCardCtrl()
    {
        if (this.cardCtrl != null) return;
        this.cardCtrl = transform.parent.GetComponent<CardCtrl>();
        Debug.Log(transform.name + ": LoadCardCtrl", gameObject);
    }
}
