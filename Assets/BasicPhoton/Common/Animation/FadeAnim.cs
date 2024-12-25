using DG.Tweening;
using UnityEngine;
public class FadeAnim : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public void Onclick_Active()
    {
        canvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            transform.parent.gameObject.SetActive(false);
        });
    }
}