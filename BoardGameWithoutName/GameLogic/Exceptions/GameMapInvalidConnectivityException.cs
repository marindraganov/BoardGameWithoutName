namespace GameLogic.Exceptions
{
    using System;

    using GameLogic.Map;

    public class GameMapInvalidConnectivityException : InvalidGameMapException
    {
        public GameMapInvalidConnectivityException(string msg)
            : base(msg)
        {
        }

        public GameMapInvalidConnectivityException(string msg, Field invalidField)
            : this(msg)
        {
            this.InvalidField = invalidField;
        }

        public Field InvalidField { get; private set; }
    }
}
