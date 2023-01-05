using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABA17_18.Abstaract_Factory;
using LABA17_18.Bilder;
namespace LABA17_18
{
    internal class TestProgram
    {

        public static void Main()
        {
            AbstractFactori factori = new ConcreteFactori();
            var Cost = factori.CreateTOtalCostMebel(111);
            var Cost1 = factori.CreateTOtalCostMebel(200);
            var Cost2 = factori.CreateTOtalCostMebel(300);
            var Cost3 = factori.CreateTOtalCostElectro(400);
            var Cost4 = factori.CreateTOtalCostElectro(500);
            var Cost5 = factori.CreateTOtalCostElectro(5000);



            OnlineStore onlineStore = new OnlineStore("BGTU");
            Client client = new Client("Oleg", 123, onlineStore);
            Client client1 = new Client("Anton", 213, onlineStore);
            Client client2 = new Client("Nikita", 321, onlineStore);
            Administrator administrator = new Administrator("AdminAdmin");


            Product product = new Product("Stul", Cost, administrator);
            Product product1 = new Product("Taburet", Cost1, administrator);
            Product product2 = new Product("Nout", Cost3, administrator);
            Product product3 = new Product("Komp", Cost4);
            var Bilder = new ProductBuilder();
            var prorab = new Prorab(Bilder);
            prorab.Build(Cost5, "PS5");
            IClone CloneProduct = product1.Clone();
            Console.WriteLine("======================\n" + CloneProduct.GetCost() + "==================\n");

            administrator.AddProductN(product3);
            administrator.AddProductN(Bilder.GetProduct());
            administrator.PrintListProduct();
            onlineStore.PrintListClient();
            onlineStore.DeliteClientList(123);
            onlineStore.PrintListClient();
            client1.AddProductInShopping(administrator.GetList());
        }
    }
}
