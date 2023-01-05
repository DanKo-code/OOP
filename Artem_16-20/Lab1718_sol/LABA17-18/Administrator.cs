using LABA17_18.Abstaract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18
{
    public class Administrator
    {
        public string AdministratorName;
        private List<Product> ListProducts;
        public Administrator(string administratorName)
        {
            AdministratorName = administratorName;
            ListProducts = new List<Product>();
        }

        public bool AddProduct(string Name,CostProduct cost)
        {
            for (int i = 0; i < ListProducts.Count; i++)
            {
               if ( ListProducts[i].Name == Name)
                {
                    return false;
                }
            }
            Product product = new Product(Name, cost);
            ListProducts.Add(product);
            return true;
        }
        public void AddProductN(Product product)
        {
            ListProducts.Add(product);
        }
        public void PrintListProduct()
        {
            int tmp = 1;
            foreach (var item in ListProducts)
            {
                Console.WriteLine($"{tmp}. Продукт {item.Name}");
                tmp++;
            }
        }
        public List<Product> GetList()
        {
            return ListProducts;
        }

        public void BanClient(int Id)
        {
            for (int i = 0; i < OnlineStore.ListClient.Count; i++)
            {
                if (Id == OnlineStore.ListClient[i].Id)
                {
                    Console.WriteLine("Клиент успешно забанен!");
                    OnlineStore.ListClient.RemoveAt(Id);
                }
            }
            Console.WriteLine("Бан не удался!");
        }
    }
}
