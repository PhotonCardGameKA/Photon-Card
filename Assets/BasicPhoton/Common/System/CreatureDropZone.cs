using System.Collections;
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
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.CompareTag("Arrow"))
            {
                StartCoroutine(AttackAnimation(eventData.pointerDrag.transform.parent.transform));

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
    private IEnumerator AttackAnimation(Transform attackingCreature)
    {
        ArrowDragDrop arrow = attackingCreature.GetComponentInChildren<ArrowDragDrop>();
        yield return new WaitForSeconds(0.05f);
        arrow.gameObject.SetActive(false);
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
        arrow.gameObject.SetActive(true);
    }
}
