namespace GameLogic.Map.Fields
{
    using System.Drawing;

    using GameLogic.Interfaces;

    public class Hospital : Field
    {
        public Hospital(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        internal void TakeCare(IHealable healable)
        {
            if (healable.HealthStatus <= 80)
            {
                healable.Heal(40);
            }
            else if (healable.HealthStatus <= 100)
            {
                healable.Heal(30);
            }
        }
    }
}
