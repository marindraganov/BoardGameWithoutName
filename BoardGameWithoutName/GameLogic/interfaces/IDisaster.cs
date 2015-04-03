namespace GameLogic.Interfaces
{
    using GameLogic.Map;

    public interface IDisaster
    {
        void Hit(Field field, int damage);
    }
}
