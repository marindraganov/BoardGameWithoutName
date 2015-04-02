namespace GameLogic.Exceptions
{
    using System;

    public class InvalidGameMapException : SystemException
    {
        public InvalidGameMapException(string msg)
            : base(msg)
        {
        }

        public InvalidGameMapException(string msg, InvalidGameMapException innerException)
            : base(msg, innerException)
        {
        }
    }
}
