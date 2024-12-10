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
    private void Awake()
    {

    }
    private void Start()
    {

        this.LoadComponents();
    }
    private void LoadComponents()
    {
        this.LoadPlayerDraw();
        this.LoadHandArea();
        this.LoadPlayerDeck();
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
}