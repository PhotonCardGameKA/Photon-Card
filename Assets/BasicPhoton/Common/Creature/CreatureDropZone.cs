using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatureDropZone : MonoBehaviour, IDropHandler // dùng trên creature bị tấn công local,
//sau do gui thong tin cho creature doi phuong
{
    public CreatureCtrl creatureCtrl;
    private void Awake()
    {
        if (this.creatureCtrl != null) return;
        this.creatureCtrl = GetComponentInParent<CreatureCtrl>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)//creature tấn công
        {
            if (eventData.pointerDrag.CompareTag("Arrow"))
            {
                StartCoroutine(AttackAnimation(eventData.pointerDrag.transform.parent.transform));

            }
        }
    }
    private void ReceiveDamage(CreatureProp propOfCreature)
    {
        object[] eventData = new object[]
        {
            propOfCreature.transform.parent.name,//name of damaged creature
            propOfCreature.currentHp,//hp of attacking creature
            propOfCreature.currentAtk//atk of attacking creature
        };

        RaiseEventOptions options = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.Others
        };
        PhotonNetwork.RaiseEvent((byte)CreatureEvent.Code.ReceiveDamage, eventData, options, ExitGames.Client.Photon.SendOptions.SendReliable);
    }
    private IEnumerator AttackAnimation(Transform attackingCreature)//anim cua creature tan cong
    {
        ArrowDragDrop arrow = attackingCreature.GetComponentInChildren<ArrowDragDrop>();
        CreatureCtrl attackingCreatureCtrl = attackingCreature.GetComponent<CreatureCtrl>();
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
        Debug.Log("Receive Damage");
        this.ReceiveDamage(attackingCreatureCtrl.creatureProp);
        yield return new WaitForSeconds(0.05f);
        arrow.gameObject.SetActive(true);
    }
}
