namespace GameLogic.Interfaces
{
    using GameLogic.Map;

    public interface IMovable
    {
        Field Field { get; }

        void MoveTo(Field target);
    }
}
