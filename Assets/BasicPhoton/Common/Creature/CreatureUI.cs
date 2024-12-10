using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatureUI : MonoBehaviour
{
    [SerializeField] private CreatureCtrl creatureCtrl;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private Image iconImage;
    public CreatureProp creatureProp;
    private void Awake()
    {
        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadCtrl();
    }
    private void LoadCtrl()
    {
        if (this.creatureCtrl != null) return;
        this.creatureCtrl = GetComponentInParent<CreatureCtrl>();
        if (this.creatureProp != null) return;
        this.creatureProp = this.creatureCtrl.creatureProp;
    }

}
