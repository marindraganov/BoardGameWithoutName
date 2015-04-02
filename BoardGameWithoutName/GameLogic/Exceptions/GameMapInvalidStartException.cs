namespace GameLogic.Exceptions
{
    using System;

    public class GameMapInvalidStartException : InvalidGameMapException
    {
        public GameMapInvalidStartException(string msg)
            : base(msg)
        {
        }
    }
}
