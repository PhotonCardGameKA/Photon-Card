using System.Collections;
using Photon.Pun;
using UnityEngine;

public class LoadingScreenRoom : MonoBehaviour
{

    public GameObject loadingScreen;
    public float fadeDuration = 1.5f;
    void Awake()
    {
        StartCoroutine(CheckScreen());
    }
    IEnumerator CheckScreen()
    {
        while (!PhotonNetwork.InLobby)
        {
            yield return null;
        }
        StartCoroutine(FadeOut());
        // Invoke(nameof(this.TurnOffLoadingScreen), 1f);

    }
    void TurnOffLoadingScreen()
    {
        this.loadingScreen.SetActive(false);
    }
    private IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = loadingScreen.GetComponent<CanvasGroup>();
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        TurnOffLoadingScreen();
    }
}