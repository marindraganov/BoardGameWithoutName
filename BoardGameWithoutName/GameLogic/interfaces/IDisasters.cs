namespace GameLogic.Disasters
{
    using Game;

    public interface IDisasters
    {

        string Name { get; }

        decimal Power { get; }

        decimal Duration { get; }

        void TakeHealth(Player player);

    }
}
