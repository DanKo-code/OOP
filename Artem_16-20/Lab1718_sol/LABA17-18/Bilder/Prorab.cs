using LABA17_18.Abstaract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18.Bilder
{
    public class Prorab
    {
        private readonly ProductBuilder _productBuilder;
        public Prorab(ProductBuilder productBuilder)
        {
            _productBuilder = productBuilder;
        }
        public void Build(ITotalCost costProduct, string Name)
        {
            _productBuilder.CostProduct(costProduct);
            _productBuilder.Name(Name);
        }
    }
}
