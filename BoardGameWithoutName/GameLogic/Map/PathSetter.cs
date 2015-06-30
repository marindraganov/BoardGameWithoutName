namespace GameLogic.Map
{
    using System.ComponentModel;

    using GameLogic.Game;
    
    internal sealed class PathSetter
    {
        private GameMap map;
        private Dice dice;
        private Game game;

        public PathSetter(Game game)
        {
            this.map = game.Map;
            this.dice = game.Dice;
            this.game = game;
            this.dice.PropertyChanged += this.Path_PropertyChanged;
            this.game.PropertyChanged += this.Path_PropertyChanged;
        }

        private void Path_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.game.CurrPlayer.Field.CanBePath)
            {
                this.ClearPaths();
            }
            else
            {
                this.RecalculatePaths(this.game.MoveValue, this.game.CurrPlayer.Field);
            }
        }

        private void RecalculatePaths(int p, Field field)
        {
            this.ClearPaths();
            this.SetPaths(p, field);
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
                    this.SetPaths(remainingLength - 1, f);
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
