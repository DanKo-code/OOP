using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABA17_18.Abstaract_Factory;

namespace LABA17_18
{
    public class Client
    {
        private string name;
        public int Id;
        private bool StatusClient = false;
        private List<Product> ListShopping;

        public Client(string name, int id, OnlineStore onlineStore)
        {
            this.name = name;
            Id = id;
            ListShopping = new List<Product>();
            onlineStore.AddClient(this);
        }
        public string GetName()
        {
            return name;
        }
        public bool GetStatusClient()
        {
            return StatusClient;
        }
        public bool SetStatusClient(bool status)
        {
            StatusClient = status;
            return StatusClient;
        }
        public void AddProductInShopping(List<Product> products)
        {
            int tmp = 100;
            while (tmp != 0)
            {
                try
                {
                    Console.WriteLine($"Выберите действие:\n" + $"Показать список товаров - 1. \n" + $"Добавить карзину - 2\n" + $"Купить товар - 3 \n" + $"" + $"Удалить товар из корзины - 4 \n" + $"Купить товар из корзины - 5 \n" + "Посмотреть содержимое корзины - 6\n" + $"Выйти из магазина - 0\n");
                    tmp = Convert.ToInt32(Console.ReadLine());
                    switch (tmp)
                    {

                        case 0:
                            Console.WriteLine("Досвидания!");
                            break;

                        case 1:
                            {
                                int tmp1 = 1;
                                foreach (var item in products)
                                {
                                    Console.WriteLine($"{tmp1}. Продукт {item.Name}, цена {item.GetCost()}");
                                    tmp1++;
                                }
                            }
                            break;

                        case 2:
                            {
                                bool check = false;
                                int tmp1 = 1;
                                foreach (var item in products)
                                {
                                    Console.WriteLine($"{tmp1}. Продукт {item.Name}");
                                    tmp1++;
                                }

                                Console.WriteLine("Чтобы добавить товар в корзину введите имя товара: ");
                                string? nameProduct = Console.ReadLine();

                                for (int i = 0; i < products.Count; i++)
                                {
                                    if (nameProduct == products[i].Name)
                                    {
                                        ListShopping.Add(new Product(products[i].Name, products[i].GetCostItem()));
                                        Console.WriteLine("Товар успешно добавлен в корзину!");
                                        check = true;
                                        break;
                                    }
                                }
                                if (!check)
                                {
                                    Console.WriteLine("Товар не найден");
                                }
                            }
                            break;
                        case 3:
                            {
                                bool check = false;
                                int tmp1 = 1;
                                foreach (var item in products)
                                {
                                    Console.WriteLine($"{tmp1}. Продукт {item.Name}");
                                    tmp1++;
                                }

                                Console.WriteLine("Чтобы купить товар в корзину введите имя товара: ");
                                string? nameProduct = Console.ReadLine();

                                for (int i = 0; i < products.Count; i++)
                                {
                                    if (nameProduct == products[i].Name)
                                    {
                                        Console.WriteLine("Товар успешно куплен!");
                                        check = true;
                                        break;
                                    }
                                }
                                if (!check)
                                {
                                    Console.WriteLine("Товар не найден");
                                }
                            }
                            break;
                        case 4:
                            {
                                bool check = false;
                                if (ListShopping.Count == 0)
                                {
                                    Console.WriteLine("Корзина пуста!");
                                    break;
                                }
                                Console.WriteLine($"Список товаров в вашей корзину");
                                int tmp1 = 1;
                                foreach (var item in ListShopping)
                                {
                                    Console.WriteLine($"{tmp1}. Продукт {item.Name}");
                                    tmp1++;
                                }
                                Console.WriteLine("Чтобы удалить один из них введите имя товара: ");
                                string? nameProduct = Console.ReadLine();
                                for (int i = 0; i < ListShopping.Count; i++)
                                {
                                    if (nameProduct == ListShopping[i].Name)
                                    {
                                        ListShopping.Remove(ListShopping[i]);
                                        Console.WriteLine("Товар успешно удалён!");
                                        check = true;
                                        break;
                                    }
                                }
                                if (!check)
                                {
                                    Console.WriteLine("Товар не найден");
                                }
                            }
                            break;
                        case 5:
                            {
                                bool check = false;
                                if (ListShopping.Count == 0)
                                {
                                    Console.WriteLine("Корзина пуста!");
                                    break;
                                }
                                Console.WriteLine($"Список товаров в вашей корзину");
                                int tmp1 = 1;
                                foreach (var item in ListShopping)
                                {
                                    Console.WriteLine($"{tmp1}. Продукт {item.Name}");
                                    tmp1++;
                                }
                                Console.WriteLine("Чтобы купить один из них введите имя товара: ");
                                string? nameProduct = Console.ReadLine();
                                for (int i = 0; i < ListShopping.Count; i++)
                                {
                                    if (nameProduct == ListShopping[i].Name)
                                    {
                                        ListShopping.Remove(ListShopping[i]);
                                        Console.WriteLine("Товар успешно приобретён!");
                                        check = true;
                                        break;
                                    }
                                }
                                if (!check)
                                {
                                    Console.WriteLine("Товар не найден");
                                }
                            }
                            break;
                        case 6:
                            {
                                int tmp1 = 1;
                                if (ListShopping.Count == 0)
                                {
                                    Console.WriteLine("Корзина пуста!");
                                    break;
                                }
                                foreach (var item in ListShopping)
                                {
                                    Console.WriteLine($"{tmp1}. Продукт {item.Name}");
                                    tmp1++;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Хм, вы наверное ошиблись, повторите попытку");
                            break;
                    }
            }
                catch (Exception ex)
            {
                Console.WriteLine("Ошибка ввода!");
            }

        }
        }

    }
}
