using LABA17_18.Abstaract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18.Bilder
{
    public class ProductBuilder : IBuilder
    {
       Product product = new Product();
        public void CostProduct(ITotalCost costProduct)
        {
            product.CostProduct = costProduct;
            product.SetCost(costProduct.GetTotalCost());
        }

        public Product GetProduct()
        {
            return product;
        }

        public void Name(string Name)
        {
           product.Name = Name;
        }

    }
}
