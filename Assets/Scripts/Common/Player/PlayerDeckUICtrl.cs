using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckUICtrl : MonoBehaviour
{
    public GameObject cardBackPrefab;
    public PlayerController playerController;
    public List<GameObject> deckUnitHolder;
    public GameObject uiHolder;
    public int topCardIndex = 30;
    private void Awake()
    {
        LoadDeckHolder();
        if (this.playerController != null) return;
        this.playerController = GetComponentInParent<PlayerController>();
    }
    public void LoadDeckHolder()
    {
        foreach (Transform child in uiHolder.transform)
        {
            deckUnitHolder.Add(child.gameObject);
        }
    }

    public void DrawUI()
    {
        GameObject topDeck = FindTopCard();
        if (topDeck == null) Debug.LogError("Out of cards");
        StartCoroutine(DrawAnimation(topDeck.GetComponent<RectTransform>(), topDeck));
        // topDeck.SetActive(false);
    }
    private IEnumerator DrawAnimation(RectTransform rectTransform, GameObject cardBackObject)
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = new Vector2(startPos.x, startPos.y + 50);
        CanvasGroup canvasGroup = cardBackObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = cardBackObject.AddComponent<CanvasGroup>();
        }
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / duration);

            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / duration);
            yield return null;
        }
        cardBackObject.SetActive(false);
    }
    public GameObject FindTopCard()
    {
        return deckUnitHolder[topCardIndex--];
    }
}