using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    partial class Lab_3
    {
        public class Production
        {
            public Production(string Name)
            {
                this.ID = this.GetHashCode();
                this.organizationName = Name;
            }

            int ID = 123;
            string organizationName;
        }
    }
}
