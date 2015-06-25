namespace GameLogic.Interfaces
{
    public interface IPay
    {
        string Name { get; }

        int Money { get; }

        void Pay(int amount);
    }
}
