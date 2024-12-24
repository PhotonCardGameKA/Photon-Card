using System.Collections;
using Photon.Pun;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;
    public GameObject loadingScreen;
    public float fadeDuration = 1.5f;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Duplicate");
        }
        Instance = this;
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
    void TurnOnLoadingScreen()
    {
        this.loadingScreen.SetActive(true);
        CanvasGroup canvasGroup = loadingScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
    }
    void TurnOffLoadingScreen()
    {
        this.loadingScreen.SetActive(false);
    }
    IEnumerator CheckRoom()
    {
        while (!PhotonNetwork.InRoom)
        {
            yield return null;
        }
        StartCoroutine(FadeOut());
        // Invoke(nameof(this.TurnOffLoadingScreen), 1f);

    }
    public void OnLoadingRoomScreen()
    {
        TurnOnLoadingScreen();
        StartCoroutine(CheckRoom());
    }
    public void OnLoadingLobbyScreen()
    {
        TurnOnLoadingScreen();
        StartCoroutine(CheckScreen());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.5f);
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