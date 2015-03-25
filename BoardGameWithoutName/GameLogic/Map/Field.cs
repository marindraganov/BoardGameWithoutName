namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public  class Field
    {


        public Field()
        {

        }
        public Color ColorField
        {
            get;
            set;
        }
        //public abstract List<NextField> NextFields
        //{
        //    get ; 
        //    set ; 
        //}
        public  string Name
        {
            get; 
            set; 
        }

    }
}
