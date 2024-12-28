using System.Collections;
using Photon.Pun;
using PlayFab;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;
    public GameObject loadingScreen;
    public float fadeDuration = 1.5f;
    public GameObject forceQuitButton;
    public GameObject timeOutButton;
    public GameObject forceQuitImg;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Duplicate");
        }
        Instance = this;
        SoundManager.Instance.PlaySound("BgLobby");
        StartCoroutine(CheckScreen());
    }
    public void forceQuitOn()
    {
        forceQuitImg.SetActive(true);
        forceQuitButton.SetActive(true);
        timeOutButton.SetActive(true);
    }
    public void forceQuitOff()
    {
        SoundManager.Instance.PlaySound("UIClick");
        forceQuitImg.SetActive(false);
        forceQuitButton.SetActive(false);
        timeOutButton.SetActive(false);
    }
    IEnumerator CheckScreen()
    {
        int countTimeTemp = 0;
        while (!PhotonNetwork.IsConnected)
        {
            yield return new WaitForSeconds(1f);
            countTimeTemp++;
            if (countTimeTemp == 20)
            {
                forceQuitOn();
                countTimeTemp = 0;
            }
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
    public Text text;
    public void OnPlayerChangeName()
    {
        PhotonNetwork.LocalPlayer.NickName = text.text;
    }
    #region Setting
    [Header("Setting")]
    public GameObject SettingScreen;
    public void OnClick_TurnOnSettingScreen()
    {
        SoundManager.Instance.PlaySound("UIClick");
        SettingScreen.SetActive(true);
    }
    public void OnClick_TurnOffSettingScreen()
    {
        SoundManager.Instance.PlaySound("UIClick");
        SettingScreen.SetActive(false);
    }
    public void OnClick_QuitGame()
    {
        SoundManager.Instance.PlaySound("UIClick");
        Application.Quit();
    }
    public GameObject confirmQuitGame;
    public void OnClick_TurnOnQuitScreen()
    {
        SoundManager.Instance.PlaySound("UIClick");
        confirmQuitGame.SetActive(true);
    }
    public void OnClick_TurnOffQuitScreen()
    {
        SoundManager.Instance.PlaySound("UIClick");
        confirmQuitGame.SetActive(false);
    }
    public void OnClick_LogOut()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        PlayerPrefs.DeleteKey("Username");
        PlayerPrefs.DeleteKey("Password");
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();

        }
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
        }
        PhotonNetwork.Disconnect();
        // StartCoroutine(FadeOut());
        PhotonNetwork.LoadLevel(2);
    }
    bool isMute = false;
    public void OnClickMute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
    #endregion
}