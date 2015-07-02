namespace GameLogic.Map.Fields
{
    using GameLogic.Interfaces;
    using System.Drawing;

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
