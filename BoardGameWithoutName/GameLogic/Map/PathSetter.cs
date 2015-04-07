using GameLogic.Game;
using System;
using System.ComponentModel;
namespace GameLogic.Map
{
    internal sealed class PathSetter
    {
        private GameMap map;
        private Dice dice;
        private Player currPlayer;

        public PathSetter(GameMap map, Dice dice, Player currPlayer)
        {
            this.map = map;
            this.dice = dice;
            this.currPlayer = currPlayer;
            this.dice.PropertyChanged += Path_PropertyChanged;
            this.currPlayer.PropertyChanged += Path_PropertyChanged;
        }

        private void Path_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Value")
            {
                RecalculatePaths(this.dice.Value, this.currPlayer.Field);
            }
        }

        private void RecalculatePaths(int p, Field field)
        {
            ClearPaths();
            SetPaths(p, field);
        }


        private void SetPaths(int remainingLength, Field field)
        {
            if (remainingLength == 0)
            {
                return;
            }
            else
            {
                foreach (var f in field.NextFields)
                {
                    f.CanBePath = true;
                    SetPaths(remainingLength - 1, f);
                }
            }
        }

        private void ClearPaths()
        {
            foreach (var field in this.map)
            {
                field.CanBePath = false;
            }
        }
    }
}
