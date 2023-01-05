using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18.Abstaract_Factory
{
    internal interface AbstractFactori
    {
        ITotalCost CreateTOtalCostElectro(double Cost);
        ITotalCost CreateTOtalCostMebel(double Cost);
    }
}
