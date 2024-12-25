using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class StartGameAnimation : MonoBehaviour
{
    public RectTransform playerBanner;
    public RectTransform opponentBanner;
    public RectTransform vsImage;

    public float slideDuration = 2f;
    public float spinDuration = 5f;
    public float slideOutDuration = 2f;

    private void Start()
    {
        SetNameBanner();
        SetupInitialPositions();
        PlayStartAnimation();

    }
    private void SetNameBanner()
    {
        TextMeshProUGUI playerText = playerBanner.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI opponentText = opponentBanner.GetComponentInChildren<TextMeshProUGUI>();
        playerText.text = "PLAYER: " + PhotonNetwork.LocalPlayer.NickName;
        opponentText.text = "ENEMY: " + "NONE";

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {

            if (playerInfo.Value.NickName != PhotonNetwork.LocalPlayer.NickName)

            {
                opponentText.text = "ENEMY: " + playerInfo.Value.NickName;
                return;
            }
        }

    }
    private void SetupInitialPositions()
    {

        // playerBanner.anchoredPosition = new Vector2(-Screen.width, -Screen.height / 4);
        // opponentBanner.anchoredPosition = new Vector2(Screen.width, Screen.height / 4);
        vsImage.gameObject.SetActive(false);
    }

    private void PlayStartAnimation()
    {
        TimerManager.Instance.isStop = true;
        playerBanner.DOAnchorPos(new Vector2(0, -Screen.height / 6), slideDuration)
            .SetEase(Ease.OutQuad);


        opponentBanner.DOAnchorPos(new Vector2(0, Screen.height / 6), slideDuration)
            .SetEase(Ease.OutQuad);


        DOVirtual.DelayedCall(slideDuration, () =>
        {
            vsImage.gameObject.SetActive(true);
            vsImage.GetComponent<CanvasGroup>().DOFade(1f, 1f)
                .SetEase(Ease.Linear);
            vsImage.DORotate(new Vector3(0, 0, 360), spinDuration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            CheckPlayers();
        });
    }
    void CheckPlayers()//neu phong du nguoi roi thi tat animation
    {
        if (GameManager.Instance.playerRef.Count == 2)
        {
            DOVirtual.DelayedCall(spinDuration, () =>
            {
                if (GameManager.Instance.playerRef.Count == 2)
                {

                    vsImage.GetComponent<CanvasGroup>().DOFade(0f, 1f)
                        .SetEase(Ease.Linear);


                    playerBanner.DOAnchorPos(new Vector2(0, -Screen.height), slideOutDuration)
                        .SetEase(Ease.InQuad);

                    opponentBanner.DOAnchorPos(new Vector2(0, Screen.height), slideOutDuration)
                        .SetEase(Ease.InQuad);
                    gameObject.GetComponent<CanvasGroup>().DOFade(0f, 1f)
                                        .SetEase(Ease.Linear);

                    DOVirtual.DelayedCall(slideOutDuration, () =>
                    {
                        vsImage.DOKill();
                        vsImage.gameObject.SetActive(false);

                        gameObject.SetActive(false);
                        TimerManager.Instance.isStop = false;
                    });
                }
            });


        }
        else
        {

            DOVirtual.DelayedCall(0.5f, () => CheckPlayers());

        }
    }
}
