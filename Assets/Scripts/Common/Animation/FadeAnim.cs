using DG.Tweening;
using UnityEngine;
public class FadeAnim : MonoBehaviour
{
    public SystemTurnManager turnManager;
    void Awake()
    {
        turnManager = GameObject.Find("EndTurnButton").GetComponent<SystemTurnManager>();
    }
    public CanvasGroup canvasGroup;
    public void Onclick_Active()
    {
        if (!turnManager.isMyTurn) return;
        canvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            transform.parent.gameObject.SetActive(false);
        });
    }
}