using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
// using PlayFab.PfEditor.EditorModels;
using Photon.Pun;
// using PlayFab.PfEditor.Json;
// using PlayFab.PfEditor.Json;
public class PlayFabAuth : MonoBehaviour
{
    // public static PlayFabAuth Instance;
    LoginWithPlayFabRequest loginRequest;
    public InputField user;
    public InputField pass;
    public InputField email;
    public GameObject turnOnRegister;
    public GameObject backToLogin;
    public bool IsAuthenticated = false;
    private void Awake()
    {
        // if (PlayFabAuth.Instance == null)
        // {
        //     PlayFabAuth.Instance = this;
        // }
        // else
        // {
        //     if (PlayFabAuth.Instance != this)
        //     {
        //         Destroy(this.gameObject);
        //     }
        // }
        // DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {

    }
    #region login
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
            PlayFabStats.Instance.GetStats();
            PlayerPrefs.SetString("USERNAME", user.text);
            PhotonNetwork.LoadLevel(1);

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
    #endregion
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
    #region PlayerStats
    public int playerElo;
    public void SetStats()
    {
        UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest();
        request.Statistics = new List<StatisticUpdate>{
            new StatisticUpdate{
                StatisticName = "Elo", Value = playerElo
            },
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,
        result =>
        {
            Debug.Log("User statistics updated");
        }, error =>
        {
            AnNotification.Instance.CustomMessage("Updated stats failed");
        });
    }
    public void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error =>
            {
                AnNotification.Instance.CustomMessage("Get stats failed");
            }
        );
    }
    void OnGetStats(GetPlayerStatisticsResult result)
    {
        foreach (var eachStat in result.Statistics)
        {
            switch (eachStat.StatisticName)
            {
                case "Elo":
                    playerElo = eachStat.Value;
                    PlayerPrefs.SetInt("Elo", playerElo);
                    break;
            }
        }
    }
    public void StartCloudUpdatePlayerStats()
    {
        ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest();
        request.FunctionName = "updatePlayerStats";
        request.FunctionParameter = new { Elo = playerElo };
        PlayFabClientAPI.ExecuteCloudScript(request, result =>
        {

        },
        error =>
        {
            Debug.LogWarning(error.GenerateErrorReport());
        });
    }
    #endregion
}
