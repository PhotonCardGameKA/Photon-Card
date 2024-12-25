using System.Collections;
using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatureDropZone : MonoBehaviour, IDropHandler
{
    public CreatureCtrl creatureCtrl;
    private void Awake()
    {
        if (this.creatureCtrl != null) return;
        this.creatureCtrl = GetComponent<CreatureCtrl>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("drop");
        if (eventData.pointerDrag.CompareTag("Bullet")) return;
        if (eventData.pointerDrag.GetComponent<ArrowDragDrop>().canDrag == false) return;//
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.transform.parent.GetComponentInChildren<CreatureProp>().pvOwnerId == creatureCtrl.creatureProp.pvOwnerId) return;
            if (eventData.pointerDrag.CompareTag("Arrow"))
            {
                AttackAnimation(eventData.pointerDrag.transform.parent.transform);
                this.BothTakeDamage_RaiseEvent(eventData.pointerDrag.transform.GetComponentInParent<CreatureCtrl>(), creatureCtrl);

            }
        }
    }
    public void BothTakeDamage(CreatureCtrl attackingCreature, CreatureCtrl receiveDamageCreature)
    {
        int attackingCreatureDmg = attackingCreature.creatureProp.currentAtk;
        int receiverCreatureDmg = receiveDamageCreature.creatureProp.currentAtk;
        attackingCreature.creatureAction.TakeDamage(receiverCreatureDmg);
        receiveDamageCreature.creatureAction.TakeDamage(attackingCreatureDmg);
    }
    public void BothTakeDamage_RaiseEvent(CreatureCtrl attackingCreature, CreatureCtrl receiveDamageCreature)
    {
        object[] eventData = new object[]
        {
            attackingCreature.transform.name,
            receiveDamageCreature.transform.name,
        };
        // Debug.Log(eventData[0] + " " + eventData[1]);
        RaiseEventOptions options = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.Others
        };
        PhotonNetwork.RaiseEvent((byte)CreatureEvent.Code.CreatureAttack, eventData, options, ExitGames.Client.Photon.SendOptions.SendReliable);

    }
    public void publicAttackAnimation(Transform attackingCreature)
    {
        AttackAnimation(attackingCreature);
    }
    public void AttackAnimation(Transform attackingCreature)
    {
        GameManager.Instance.ActivePreventerCreature(true);
        TimerManager.Instance.BonusTime();
        DOVirtual.DelayedCall(0.05f, () =>
   {
       ArrowDragDrop arrow = attackingCreature.GetComponentInChildren<ArrowDragDrop>();
       if (arrow != null)
       {
           arrow.canDrag = false;
           arrow.gameObject.SetActive(false);
       }

       Vector3 originalPosition = attackingCreature.position;
       Vector3 targetPosition = transform.position;

       float animationDuration = 0.5f;


       attackingCreature.DOMove(targetPosition, animationDuration)
           .SetEase(Ease.InOutQuad)
           .OnComplete(() =>
           {
               CreatureAnimRef animRef = attackingCreature.GetComponent<CreatureAnimRef>();
               animRef.attack1Anim.SetActive(true);
               animRef.attack2Anim.SetActive(true);
               DOVirtual.DelayedCall(0.2f, () =>
               {
                   attackingCreature.DOMove(originalPosition, animationDuration)
                       .SetEase(Ease.InOutQuad)
                       .OnComplete(() =>
                       {
                           DOVirtual.DelayedCall(0.05f, () =>
                           {
                               Debug.Log("Damage dealt to enemy!");
                               BothTakeDamage(attackingCreature.GetComponent<CreatureCtrl>(), this.creatureCtrl);


                               if (arrow != null && !arrow.gameObject.activeSelf)
                               {
                                   arrow.gameObject.SetActive(true);
                               }
                               animRef.attack1Anim.SetActive(false);
                               animRef.attack2Anim.SetActive(false);
                               GameManager.Instance.ActivePreventerCreature(false);
                           });
                       });
               });
           });
   });
    }//loi mang chan
}
