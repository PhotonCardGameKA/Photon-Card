public class CheckDeadHero : CreatureAction
{
    protected override void Death()
    {
        base.Death();
        WinCondition.Instance.CheckHp();
    }
}