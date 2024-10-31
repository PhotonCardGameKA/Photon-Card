using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PhotonCardUI : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;

    private void HideCardBack()
    {
        cardBack.SetActive(false);
    }
    private void ShowCardBack()
    {
        cardBack.SetActive(true);
    }

}