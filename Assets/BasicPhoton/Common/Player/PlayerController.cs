using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public static PlayerController Instance;
    [SerializeField] private PlayerDraw playerDraw;
    public PlayerDraw PlayerDraw => playerDraw;
    [SerializeField] private PlayerHandArea playerHandArea;
    public PlayerHandArea PlayerHandArea => playerHandArea;
    [SerializeField] private PlayerDeck playerDeck;
    public PlayerDeck PlayerDeck => playerDeck;
    public PlayerDeckUICtrl playerDeckUICtrl;
    private void Awake()
    {
        this.LoadComponents();
    }
    private void Start()
    {


    }
    private void LoadComponents()
    {
        this.LoadPlayerDraw();
        this.LoadHandArea();
        this.LoadPlayerDeck();
        this.LoadDeckUICtrl();
    }
    private void LoadPlayerDraw()
    {
        if (this.playerDraw != null) return;
        playerDraw = transform.GetComponentInChildren<PlayerDraw>();
    }
    private void LoadHandArea()
    {
        if (this.playerHandArea != null) return;
        playerHandArea = transform.GetComponentInChildren<PlayerHandArea>();
    }
    private void LoadPlayerDeck()
    {
        if (this.playerDeck != null) return;
        playerDeck = transform.GetComponentInChildren<PlayerDeck>();
    }
    private void LoadDeckUICtrl()
    {
        if (this.playerDeckUICtrl != null) return;
        playerDeckUICtrl = transform.GetComponentInChildren<PlayerDeckUICtrl>();
    }
}