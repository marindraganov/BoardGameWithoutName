namespace GameLogic.Institutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Map;

    public class Bank : Field
    {

        private string name;
        public Bank(string nameBank)
        {
            this.Name = nameBank;
        }

        public  System.Drawing.Color ColorField
        {
            get 
            {
                return System.Drawing.Color.Violet;
            }
        }

        public  string Name
        {
            get
            {
                return name;
            }
            set
            {
                name=value;
            }
        }

        //public override List<NextField> NextFields
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
