using UnityEditor;
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
    public PlayerMana playerMana;
    public PlayerManaUI playerManaUI;
    public SystemTurnManager endTurnButton;
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
        this.LoadTurnManager();
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
    public void LoadMana()
    {
        if (this.playerMana != null) return;
        this.playerMana = transform.GetComponentInChildren<PlayerMana>();
    }
    private void LoadManaUI()
    {
        if (this.playerManaUI != null) return;
        this.playerManaUI = transform.GetComponentInChildren<PlayerManaUI>();
    }
    private void LoadTurnManager()
    {
        if (this.endTurnButton == null)
        {
            this.endTurnButton = GameObject.Find("EndTurnButton").GetComponent<SystemTurnManager>();
        }
    }
}