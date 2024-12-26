using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PhotonCardUI : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;

    public GameObject cardName;
    public GameObject hpImage;
    public GameObject description;
    public GameObject cost;
    public GameObject atkImage;
    //ui
    public TextMeshProUGUI cardNameText;
    public Image iconImage;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI descriptionText;
    //ref
    [SerializeField] private PhotonCardCtrl photonCardCtrl;
    [SerializeField] private PhotonCardProp photonCardProp;
    void Awake()
    {
        if (this.photonCardCtrl != null) return;
        this.photonCardCtrl = GetComponentInParent<PhotonCardCtrl>();
        // this.photonCardProp = photonCardCtrl.photonCardProp;
        this.InitInfo();
        this.InitUI();
    }
    public void UnHideCardBack()
    {
        this.cardBack.SetActive(true);
    }
    public void UpdateUI()
    {
        this.hpText.text = photonCardProp.currentHp.ToString();
        this.atkText.text = photonCardProp.currentAtk.ToString();
        this.costText.text = photonCardProp.cost.ToString();
        this.descriptionText.text = photonCardProp.description;

    }
    public void InitUI()
    {
        this.UpdateUI();
        this.iconImage.sprite = photonCardProp.cardIcon;
        this.cardNameText.text = photonCardProp.cardName;
    }


    public void InitInfo()
    {

        this.photonCardProp = photonCardCtrl.transform.GetComponentInChildren<PhotonCardProp>();
        this.hpText = this.hpImage.GetComponentInChildren<TextMeshProUGUI>();
        this.atkText = this.atkImage.GetComponentInChildren<TextMeshProUGUI>();
        this.costText = this.cost.GetComponentInChildren<TextMeshProUGUI>();
        this.descriptionText = this.description.GetComponentInChildren<TextMeshProUGUI>();
        this.cardNameText = this.cardName.GetComponentInChildren<TextMeshProUGUI>();
    }

}