namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameSettings
    {
        public GameSettings(int gameDurationMinutes, int turnDurationSeconds, bool isAllowedToEnterValueOfDice = true)
        {
            this.GameDurationMinutes = gameDurationMinutes;
            this.TurnDurationSeconds = turnDurationSeconds;
            this.IsAllowedToEnterValueOfDice = isAllowedToEnterValueOfDice;
        }

        public int GameDurationMinutes { get; private set; }

        public int TurnDurationSeconds { get; private set; }

        public bool IsAllowedToEnterValueOfDice { get; set; }
    }
}