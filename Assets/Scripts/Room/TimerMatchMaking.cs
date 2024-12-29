using Photon.Pun;
using TMPro;
using UnityEngine;

public class TimerMatchMaking : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public float matchMakingTime = 60f;
    public TextMeshProUGUI timeText;
    void Start()
    {
        timeIsRunning = true;
    }
    void Update()
    {
        if (timeIsRunning == true)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
                CheckTimeMatchMaking();
            }
        }
    }
    void CheckTimeMatchMaking()
    {
        if (timeRemaining >= matchMakingTime)
        {
            timeIsRunning = false;
            AnNotification.Instance.CustomMessage("No suitable opponent found. Would you like to try again?");
            PhotonNetwork.LeaveRoom(true);
        }
    }
    void OnEnable()
    {
        timeRemaining = 0;
        timeIsRunning = true;
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}