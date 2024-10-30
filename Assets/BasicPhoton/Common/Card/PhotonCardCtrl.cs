using UnityEngine;

public class PhotonCardCtrl : MonoBehaviour
{
    [SerializeField] private PhotonCardUI photonCardUI;

    void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        this.LoadCardUI();
    }
    protected virtual void LoadCardUI()
    {
        if (this.photonCardUI != null) return;
        this.photonCardUI = GetComponentInChildren<PhotonCardUI>();
    }
}