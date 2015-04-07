using GameLogic.Game;
using System;
using System.ComponentModel;
namespace GameLogic.Map
{
    internal sealed class PathSetter
    {
        private GameMap map;
        private Dice dice;
        private Game.Game game;

        public PathSetter(Game.Game game)
        {
            this.map = game.Map;
            this.dice = game.Dice;
            this.game = game;
            this.dice.PropertyChanged += Path_PropertyChanged;
            this.game.PropertyChanged += Path_PropertyChanged;
        }

        private void Path_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.game.CurrPlayer.Field.CanBePath)
            {
                ClearPaths();
            }
            else
            {
                RecalculatePaths(this.dice.Value, this.game.CurrPlayer.Field);
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
