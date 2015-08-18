namespace ViewLayerWPF.ActionVisualizers
{
    using System.ComponentModel;

    using GameLogic.Disasters;
    using GameLogic.Game;
    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;

    public class Visualizer
    {
        private static Visualizer instance = new Visualizer();

        private Visualizer()
        {
        }

        public static Visualizer Instance 
        { 
            get 
            {
                return instance;
            } 
        }

        public void ShowOffer(Offer offer)
        {
            if (offer != null && offer.IsValid)
            {
                ActionWindow window = new ActionWindow();
                window.Show();
                window.ShowOffer(offer);
            } 
        }

        public void ShowStreetPanel(Street street)
        {
            if (street != null)
            {
                ActionWindow window = new ActionWindow();
                window.Show();
                window.ShowStreetPanel(street);
            }
        }

        public void ShowDisaster(Disaster disaster)
        {
            if (disaster != null)
            {
                ActionWindow window = new ActionWindow();
                window.Show();
                window.ShowDisaster(disaster);
            }
        }

        public void ShowWinWindow(Player winner)
        {
            if (winner != null)
            {
                ActionWindow window = new ActionWindow();
                window.Width = 570;
                window.Show();
                window.ShowWinner(winner);
            }
        }
    }
}
