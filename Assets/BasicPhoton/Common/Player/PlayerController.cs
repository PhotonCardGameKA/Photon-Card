using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public static PlayerController Instance;
    [SerializeField] private PlayerDraw playerDraw;
    public PlayerDraw PlayerDraw => playerDraw;
    [SerializeField] private PlayerHandArea playerHandArea;
    public PlayerHandArea PlayerHandArea => playerHandArea;
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
}