namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameLogic.Map.Fields;

    public class Map
    {
        private List<Field> fields;

        public Start Start { get; set; }

        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            // TODO - will be implemented with DFS
            return true;
        }
    }
}