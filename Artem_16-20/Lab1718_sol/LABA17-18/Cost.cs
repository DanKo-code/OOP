using LABA17_18.Abstaract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18
{
    public class CostProduct : ITotalCost
    {
        private double Cost;
        private double Tax;

        public CostProduct(double Cost, double Tax)
        {
            this.Cost = Cost;
            this.Tax = Tax;
        }
        public double GetTotalCost()
        {
            var res = Cost * Tax; 
            return Cost * Tax;
        }
        public double GetCost() => Cost;
    }
}
