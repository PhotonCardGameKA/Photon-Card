using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using PlayFab.PfEditor.EditorModels;
using Photon.Pun;
public class PlayFabAuth : MonoBehaviour
{
    LoginWithPlayFabRequest loginRequest;
    public InputField user;
    public InputField pass;
    public InputField email;
    public GameObject turnOnRegister;
    public GameObject backToLogin;
    public bool IsAuthenticated = false;
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Login()
    {
        SoundManager.Instance.PlaySound("UIClick");
        if (string.IsNullOrEmpty(user.text) || string.IsNullOrEmpty(pass.text))
        {
            Debug.Log("Username or Password is empty.");
            AnNotification.Instance.CustomMessage("Username or Password is empty.");
            return;
        }

        loginRequest = new LoginWithPlayFabRequest
        {
            Username = user.text,
            Password = pass.text

        };

        PlayFabClientAPI.LoginWithPlayFab(loginRequest, result =>
        {
            IsAuthenticated = true;
            AnNotification.Instance.CustomMessage("LoginSuccess");
            Debug.Log("PlayFabId:" + result.PlayFabId);
            Debug.Log("SessionTicket:" + result.SessionTicket);
            PhotonNetwork.LoadLevel(0);

        }, error =>
        {
            IsAuthenticated = false;
            Debug.LogError($"Login failed: {error.ErrorMessage}");
            AnNotification.Instance.CustomMessage("login Failed");
        });
    }

    public void OnClickTurnOnRegister()
    {
        SoundManager.Instance.PlaySound("UIClick");
        backToLogin.SetActive(false);
        turnOnRegister.SetActive(true);
    }
    public void OnClickBackToLogin()
    {
        SoundManager.Instance.PlaySound("UIClick");
        backToLogin.SetActive(true);
        turnOnRegister.SetActive(false);
    }
    public void Register()
    {
        SoundManager.Instance.PlaySound("UIClick");
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
        request.Email = email.text;
        request.Username = user.text;
        request.Password = pass.text;
        request.DisplayName = user.text;
        PlayFabClientAPI.RegisterPlayFabUser(request, result =>
        {
            AnNotification.Instance.CustomMessage("Register Success");
        }, error =>
        {
            string textError = error.GenerateErrorReport();
            Debug.LogWarning(textError);
            AnNotification.Instance.CustomMessage(error.ErrorMessage);
        }, null);
    }
    #region recovery
    public InputField recoveryEmail;
    public GameObject recoveryPannel;
    public void OnClick_TurnOnRecovery()
    {
        SoundManager.Instance.PlaySound("UIClick");
        recoveryPannel.SetActive(true);
    }
    public void OnClick_TurnOffRecovery()
    {
        SoundManager.Instance.PlaySound("UIClick");
        recoveryPannel.SetActive(false);
    }
    public void RecoveryPassword()
    {
        SoundManager.Instance.PlaySound("UIClick");
        SendAccountRecoveryEmailRequest request = new SendAccountRecoveryEmailRequest();
        request.Email = recoveryEmail.text;
        request.TitleId = PlayFabSettings.TitleId;
        PlayFabClientAPI.SendAccountRecoveryEmail(request, result =>
        {
            AnNotification.Instance.CustomMessage("Please check your mail");
        }, error =>
        {
            AnNotification.Instance.CustomMessage(error.ErrorMessage);
        });
    }
    #endregion
    #region Screen
    public GameObject loadingScreen;
    public float fadeDuration = 1.5f;
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
    #endregion

    #region Settings
    public GameObject settingScreen;
    public GameObject confirmQuitScreen;
    public void OnClick_SettingOn()
    {
        settingScreen.SetActive(true);
    }
    public void OnClick_SettingOff()
    {
        settingScreen.SetActive(false);
    }
    public void OnClick_QuitGame()
    {
        Application.Quit();
    }
    public void OnClick_CloseQuit()
    {
        confirmQuitScreen.SetActive(false);
    }
    public void OnClick_OpenQuit()
    {
        confirmQuitScreen.SetActive(true);
    }
    #endregion
}
