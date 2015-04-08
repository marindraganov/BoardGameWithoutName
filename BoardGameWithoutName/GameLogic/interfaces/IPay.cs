namespace GameLogic.Interfaces
{
    public interface IPay
    {
        int Money { get; }

        void Pay(int amount);
    }
}
