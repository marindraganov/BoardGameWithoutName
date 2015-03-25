namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public abstract class Field
    {
        public abstract  Color Color
        {
            get;
        }
        //public abstract List<NextField> NextFields
        //{
        //    get ; 
        //    set ; 
        //}
        public abstract string Name
        {
            get; 
            set; 
        }

    }
}
