using LABA17_18.Abstaract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18.Bilder
{
    public interface IBuilder
    {
        void Name(string Name);
        void CostProduct(ITotalCost costProduct);
        Product GetProduct();
    }
}
