using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public PlayerController playerController;
    #region player
    public bool isMyTurn = false;
    public int maxHp = 30;
    public int currentHp = 30;
    public int pAtk = 0;
    public int cardInHand = 0;
    public int maxCardInHand = 8;
    public int currentMp = 0;
    public int unlockedMp = 1;
    public int maxMp = 9;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    bool isDefeated()
    {
        return (currentHp <= 0);
    }
    void actionDefeated()
    {

    }
    void takeDamage(int dmg)
    {
        if (this.currentHp - dmg > 0) this.currentHp -= dmg;
        else
        {
            this.currentHp = 0;
            actionDefeated();
        }
    }
    void refreshMp(int mp)
    {
        if (currentMp + mp > unlockedMp) currentMp = unlockedMp;
        else currentMp += mp;
    }
    void unlockMp(int mp)
    {
        if (this.unlockedMp + mp > maxMp) this.unlockedMp = maxMp;
        else this.unlockedMp += mp;
    }
    void healCharacter(int healAmount)
    {
        if (currentHp + healAmount > maxHp) currentHp = maxHp;
        else currentHp += healAmount;
    }
    #endregion
}