namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Drawing;
    using Game;
    public class StartField: Field
    {
        
        public StartField()
        {
           

        }

        public static  Color ColorField
        {
            get { return Color.Yellow; }
        }

        public static string Name
        {
            get
            {
              return "Start Filed";
            }
            
            set
            {
                ;
            }
        }

    
    }
}
