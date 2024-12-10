using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCtrl : MonoBehaviour
{
    public CreatureProp creatureProp;
    public CreatureUI creatureUI;
    private void Awake()
    {
        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadUI();
        this.LoadProp();
    }
    private void LoadUI()
    {
        if (this.creatureUI != null) return;
        this.creatureUI = GetComponentInChildren<CreatureUI>();
    }
    private void LoadProp()
    {
        if (this.creatureProp != null) return;
        this.creatureProp = GetComponentInChildren<CreatureProp>();
    }
}
