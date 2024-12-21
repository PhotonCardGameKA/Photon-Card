using System.Collections;
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
                StartCoroutine(AttackAnimation(eventData.pointerDrag.transform.parent.transform));
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
        StartCoroutine(AttackAnimation(attackingCreature));
    }
    private IEnumerator AttackAnimation(Transform attackingCreature)
    {
        ArrowDragDrop arrow = attackingCreature.GetComponentInChildren<ArrowDragDrop>();
        yield return new WaitForSeconds(0.05f);
        // int flag = 0;
        // if (arrow != null)
        // {
        //     flag = 1;
        if (arrow != null)
        {
            arrow.canDrag = false;
            arrow.gameObject.SetActive(false);

        }

        // }
        Vector3 originalPosition = attackingCreature.position;
        Vector3 targetPosition = transform.position;

        float animationDuration = 0.5f;
        float elapsedTime = 0f;

        // Di chuyển quái vật đến mục tiêu
        while (elapsedTime < animationDuration)
        {
            attackingCreature.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        attackingCreature.position = targetPosition;

        // Tạm dừng ở mục tiêu
        yield return new WaitForSeconds(0.2f);

        elapsedTime = 0f;

        // Quay lại vị trí ban đầu
        while (elapsedTime < animationDuration)
        {
            attackingCreature.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        attackingCreature.position = originalPosition;

        // Gây damage (tạm thời chỉ log ra)
        Debug.Log("Damage dealt to enemy!");
        BothTakeDamage(attackingCreature.GetComponent<CreatureCtrl>(), this.creatureCtrl);
        yield return new WaitForSeconds(0.05f);
        if (arrow != null && !arrow.gameObject.activeSelf)
            arrow.gameObject.SetActive(true);


    }
}
