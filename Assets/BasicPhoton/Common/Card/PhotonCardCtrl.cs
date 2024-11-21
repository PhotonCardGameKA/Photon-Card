using UnityEngine;

public class PhotonCardCtrl : MonoBehaviour
{
    [SerializeField] public PhotonCardUI photonCardUI;
    [SerializeField] public PhotonCardProp photonCardProp;

    void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        this.LoadCardUI();
        this.LoadCardProp();
    }
    protected virtual void LoadCardUI()
    {
        if (this.photonCardUI != null) return;
        this.photonCardUI = GetComponentInChildren<PhotonCardUI>();
    }
    protected virtual void LoadCardProp()
    {
        if (this.photonCardProp != null) return;
        this.photonCardProp = GetComponentInChildren<PhotonCardProp>();
    }
}