using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BMenuUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] NetworkManager networkManager;
    [Header("Button")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button firstTeamButton;
    [SerializeField] private Button secondTeamButton;

    [Header("Text")]
    [SerializeField] private Text resulText;
    [SerializeField] private Text connectionStatusText;
    [Header("Screen GameObject")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject connectScreen;
    [SerializeField] private GameObject teamSelectionScreen;
    [SerializeField] private GameObject gameModeSelectionScreen;
    [Header("Other")]
    [SerializeField] private Dropdown gameLevelSelection;

    void Awake()
    {
        gameLevelSelection.AddOptions(Enum.GetNames(typeof(ChessLevel)).ToList());
        OnGameLaunched();
    }
    private void OnGameLaunched()
    {
        DisableAllScreen();
        gameModeSelectionScreen.SetActive(true);
    }
    public void OnSinglePlayerModeSelected()
    {
        DisableAllScreen();
    }
    public void OnMultiPlayerModeSelected()
    {
        connectionStatusText.gameObject.SetActive(true);
        DisableAllScreen();
        connectScreen.SetActive(true);
    }
    public void OnConnect()
    {
        networkManager.SetPlayerLevel((ChessLevel)gameLevelSelection.value);
        networkManager.Connect();
    }

    public void DisableAllScreen()
    {
        gameOverScreen.SetActive(false);
        connectScreen.SetActive(false);
        teamSelectionScreen.SetActive(false);
        gameModeSelectionScreen.SetActive(false);
    }

    public void SetConnectionStatus(string status)
    {
        connectionStatusText.text = status;
    }
    public void ShowTeamSelectionScreen()
    {
        DisableAllScreen();
        teamSelectionScreen.SetActive(true);
    }
    public void SelectTeam(int team)
    {
        networkManager.SelectTeam(team);
    }
    internal void RestrictTeamChoice(TeamSelector occupiedTeam)
    {
        var buttonToDeActive = occupiedTeam == TeamSelector.FirstTeam ? firstTeamButton : secondTeamButton;
        buttonToDeActive.interactable = false;
    }
}
