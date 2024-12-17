using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAction : MonoBehaviour
{
    public CreatureCtrl creatureCtrl;
    private void Awake()
    {
        if (this.creatureCtrl != null) return;
        this.creatureCtrl = GetComponentInParent<CreatureCtrl>();
    }
    public void TakeDamage(int dmg)
    {
        CreatureProp prop = this.creatureCtrl.creatureProp;
        prop.DeductDamage(dmg);
        CreatureUI ui = this.creatureCtrl.creatureUI;
        ui.SetUI();
        CheckDeath();
    }
    public void CheckDeath()
    {
        if (this.creatureCtrl.creatureProp.IsDead()) Death();

    }
    public void Death()//temp
    {
        transform.parent.gameObject.SetActive(false);
    }
}
