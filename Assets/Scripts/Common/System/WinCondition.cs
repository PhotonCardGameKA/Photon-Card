using Photon.Pun;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public static WinCondition Instance;
    public GameObject winScreen;
    public GameObject loseScreen;
    public bool isWin = false;
    public bool isLose = false;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Duplicate singleton");
        };
        Instance = this;
        LoadPlayer();
        LoadScreen();
    }
    public CreatureProp player;
    public CreatureProp enemy;
    void LoadPlayer()
    {
        if (player == null)
        {
            player = GameObject.Find("PlayerIconE").GetComponentInChildren<CreatureProp>();
        }
        if (enemy == null)
        {
            enemy = GameObject.Find("PlayerIconE1").GetComponentInChildren<CreatureProp>();
        }
    }
    void LoadScreen()
    {
        if (winScreen == null)
        {
            winScreen = transform.Find("Win").gameObject;
        }
        if (loseScreen == null)
        {
            loseScreen = transform.Find("Lose").gameObject;
        }
    }
    void TurnWinScreenOn()
    {
        winScreen.SetActive(true);
        SoundManager.Instance.PlaySound("victory");
    }
    void TurnLoseScreenOn()
    {
        loseScreen.SetActive(true);
        SoundManager.Instance.PlaySound("defeat");
    }
    public void CheckHp()//regular win && lose
    {
        if (enemy.currentHp > 0 && player.currentHp > 0) return;
        if (enemy.currentHp <= 0)
        {
            // isWin = true;
            // isLose = false;
            // TimerManager.Instance.isStop = true;
            // TurnWinScreenOn();
            WinProcess();
        }
        if (player.currentHp <= 0)
        {
            // isWin = false;
            // isLose = true;
            // TimerManager.Instance.isStop = true;
            // TurnLoseScreenOn();
            LoseProcess();
        }
    }
    public void WinProcess()
    {

        isWin = true;
        isLose = false;
        TimerManager.Instance.isStop = true;
        TurnWinScreenOn();

    }
    public void LoseProcess()
    {
        isWin = false;
        isLose = true;
        TimerManager.Instance.isStop = true;
        TurnLoseScreenOn();
    }
}