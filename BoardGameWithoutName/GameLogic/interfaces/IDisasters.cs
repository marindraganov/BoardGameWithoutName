namespace GameLogic.Disasters
{
    using Game;

    public interface IDisasters
    {

        string Name { get; }

        int Power { get; }

        int Duration { get; }

        void TakeHealth(Player player);

    }
}
