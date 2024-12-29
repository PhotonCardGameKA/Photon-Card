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
public class PlayFabStats : MonoBehaviour
{
    public static PlayFabStats Instance;

    private void Awake()
    {
        // GetStats();
        if (PlayFabStats.Instance == null)
        {
            PlayFabStats.Instance = this;
        }
        else
        {
            if (PlayFabStats.Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

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
        if (playerElo <= 0) playerElo = 0;
        request.FunctionParameter = new { Elo = playerElo };
        PlayFabClientAPI.ExecuteCloudScript(request, result =>
        {
            // Debug.Log(JsonWrapper.SerializeObject(result.FunctionResult));
            // JsonObject jsonResult = (JsonObject)result.FunctionResult;
            // object messageValue;
            // result.FunctionResult.("messageValue", out messageValue);
            // Debug.Log((string)messageValue);
        },
        error =>
        {
            Debug.LogWarning(error.GenerateErrorReport());
        });
    }
    #endregion
}
