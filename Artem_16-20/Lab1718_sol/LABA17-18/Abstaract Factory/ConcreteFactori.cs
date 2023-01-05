using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABA17_18;

namespace LABA17_18.Abstaract_Factory
{
    internal class ConcreteFactori : AbstractFactori 
    {
        public ITotalCost CreateTOtalCostElectro (double Cost)
        {
            return new CostProduct(Cost, 0.25);
        }
        public ITotalCost CreateTOtalCostMebel(double Cost)
        {
            return new CostProduct(Cost, 0.15) ;
        }
    }
}
