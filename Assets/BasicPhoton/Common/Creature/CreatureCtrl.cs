using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCtrl : MonoBehaviour
{
    public CreatureProp creatureProp;
    public CreatureUI creatureUI;
    public CreatureDropZone creatureDropZone;
    public CreatureActionHandle creatureActionHandle;
    private void Awake()
    {
        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadUI();
        this.LoadProp();
        this.LoadDropZone();
        // this.LoadAction();
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
    private void LoadDropZone()
    {
        if (this.creatureDropZone != null) return;
        this.creatureDropZone = GetComponent<CreatureDropZone>();
    }
    private void LoadAction()
    {
        if (this.creatureActionHandle != null) return;
        this.creatureActionHandle = GetComponentInChildren<CreatureActionHandle>();
    }
}
