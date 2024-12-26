using DG.Tweening;
using UnityEngine;
public class SummonAnim : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    void OnEnable()
    {

        canvasGroup.alpha = 1f;


        canvasGroup.DOFade(0f, 2f).OnComplete(() => gameObject.SetActive(false));
    }
}