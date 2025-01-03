using UnityEngine;

public class PhotonCardCtrl : MonoBehaviour
{
    [SerializeField] public PhotonCardUI photonCardUI;
    [SerializeField] public PhotonCardProp photonCardProp;
    public DragDrop dragDrop;
    public CardInfo cardInfo;
    // [SerializeField] public PhotonCardSpawner photonCardSpawner;

    void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        this.LoadCardUI();
        this.LoadCardProp();
        this.LoadCardSpawner();
        this.LoadDragDrop();
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
    protected virtual void LoadCardSpawner()
    {
        // if (this.photonCardSpawner != null) return;
        // this.photonCardSpawner = GetComponentInChildren<PhotonCardSpawner>();
    }
    protected virtual void LoadDragDrop()
    {
        if (this.dragDrop != null) return;
        this.dragDrop = GetComponent<DragDrop>();
    }
}