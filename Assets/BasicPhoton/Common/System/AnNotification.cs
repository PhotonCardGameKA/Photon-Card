using System.Collections;
using TMPro;
using UnityEngine;

public class AnNotification : MonoBehaviour
{
    public static AnNotification Instance;
    public float fadeDuration = 0.5f;
    public float displayDuration = 4.0f;
    [SerializeField] CanvasGroup canvasGroup;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Duplicate", gameObject);
        }
        Instance = this;
    }
    public GameObject notificationBar;
    public TextMeshProUGUI notificationText;

    public void CustomMessage(string msg)
    {
        notificationText.text = msg;
        StartCoroutine(FadeInOut());

    }
    private IEnumerator FadeInOut()
    {
        notificationBar.SetActive(true);
        yield return Fade(0f, 1f);


        yield return new WaitForSeconds(displayDuration);


        yield return Fade(1f, 0f);

        notificationBar.SetActive(false);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }

}