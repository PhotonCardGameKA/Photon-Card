using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 30f;
    float timeToChangeTurn = 30f;
    [SerializeField] SystemTurnManager systemTurnManager;
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }
    void Update()
    {
        if (remainingTime > 0)
        {

            remainingTime -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            remainingTime = 0;
            AutoChangeTurn();
            //over
        }


    }
    void UpdateUI()
    {
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}", seconds);
    }
    void AutoChangeTurn()
    {
        if (!systemTurnManager.isMyTurn) return;
        ResetTime();
        systemTurnManager.OnNextTurnButtonClicked();
    }
    public void ResetTime()
    {
        remainingTime = timeToChangeTurn;
    }
}
