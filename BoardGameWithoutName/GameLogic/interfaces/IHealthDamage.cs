namespace GameLogic.Interfaces
{
    public interface IHealthDamageable : IHealth
    {
        void TakeHealth(int healthDamage);
    }
}
