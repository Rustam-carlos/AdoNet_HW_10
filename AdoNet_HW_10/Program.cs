using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add_Product();
            //Add_Sellers()

            for (int i = 1, x = 0; i > x; i++)
            {
                int choise = 0;
                Console.WriteLine("Добро пожаловать!!!");
                Client NewClient = new Client();
                Menu();
                choise = int.Parse(Console.ReadLine());
                if ((choise != 1) & (choise != 2) & (choise != 3) & (choise != 4) & (choise != 5) & (choise != 6))
                    Console.WriteLine("ОШИБКА ВВОДА!!! СОБЕРИСЬ ТРЯПКА!!!");
                else
                {
                    Console.Clear();
                    using (SalesContext context = new SalesContext())
                    {
                        switch (choise)
                        {
                            case 1:                                
                                Client admin = new Client { FullName = "Rustam", TelNumber = "+7-77777777", Password = "123456" };
                                context.Clients.Add(admin);
                                //context.SaveChanges();
                                
                                Console.WriteLine("Введите пожалуйста Ваше полное имя");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите пожалуйста Ваш номер телефона");
                                string telNumber = Console.ReadLine();
                                Console.WriteLine("Введите пароль");
                                string password = Console.ReadLine();

                                NewClient = new Client { FullName = name, TelNumber = telNumber, Password = password };

                                var getName = (from Client in context.Clients
                                               where Client.FullName.Equals(name)
                                               select Client).FirstOrDefault();
                                var getPass = (from Client in context.Clients
                                               where Client.Password.Equals(password)
                                               select Client).FirstOrDefault();
                                if (NewClient.FullName == getName.FullName & NewClient.Password == getPass.Password)
                                    Console.WriteLine("Добро пожаловать,  " + NewClient.FullName + " Рад что снова к нам заглянули!");
                                else
                                {
                                    context.Clients.Add(NewClient);
                                    context.SaveChanges();
                                    Console.WriteLine("Добро пожаловать,  "
                                        + NewClient.FullName + " Рад что присоеденились к нам!");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            case 2:
                                var products = context.Products;
                                Console.WriteLine("Список доступных продуктов:");
                                foreach (Product n in products)
                                {
                                    Console.WriteLine("{0}.{1}.{2}.{3}.{4}", n.ID, n.Name, n.category, n.FirmName, n.Price);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            case 3:
                                Console.WriteLine("Введите ID товара для добавления в корзину");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите его колличество");
                                int cnt = int.Parse(Console.ReadLine());
                                var ProdID = (from Product in context.Products
                                              where Product.ID.Equals(id)
                                              select Product).FirstOrDefault();
                                Random rand = new Random();
                                int temp;
                                temp = rand.Next(1, 3);
                                var _seller = (from Seller in context.Sellers
                                               where Seller.ID.Equals(temp)
                                               select Seller).FirstOrDefault();
                                Order newOrder = new Order { client = NewClient, seller = _seller, Date = DateTime.Now, product = ProdID, ProductCount = cnt, Sum = ProdID.Price * cnt };
                                context.Orders.Add(newOrder);
                                context.SaveChanges();
                                List<Order> _orders = new List<Order>();
                                _orders.Add(newOrder);
                                Basket newBasket = new Basket { client = NewClient, orders = _orders };
                                context.Baskets.Add(newBasket);
                                context.SaveChanges();
                                Console.WriteLine("Ваш товар ушпешно добавлен в корзину");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            case 4:
                                var basketShow = context.Baskets;
                                Console.WriteLine("Содержимое Вашей корзины:");
                                foreach (Basket n in basketShow)
                                {
                                    Console.WriteLine("{0}.{1}.{2}.{3}", n.ID, n.client.FullName, n.orders);
                                }
                                Console.Clear();
                                continue;
                            case 5:                                
                                Console.WriteLine("Введите ID продукта, который желаете удалить");
                                int Num = int.Parse(Console.ReadLine());
                                var getID = (from Basket in context.Baskets
                                             where Basket.ID.Equals(Num)
                                             select Basket).FirstOrDefault();
                                context.Baskets.Remove(getID);
                                context.SaveChanges();
                                Console.WriteLine("Продукт удален");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            case 6:
                                i = 0;
                                break;
                        }
                    }
                }
            }
            Console.ReadKey();
        }

       

        private static void Add_Product()
        {
            Category category1 = new Category { Name = "Продукты" };
            Category category2 = new Category { Name = "Напитки" };
            Category category3 = new Category { Name = "Бытовая химия" };
            Category category4 = new Category { Name = "Фрукты и овощи" };     

            Product product1 = new Product { Name = "Молоко", category = category1, FirmName = "ФудМастер", Price = 150 };
            Product product2 = new Product { Name = "Fairy", category = category3, FirmName = "Проклят как Гембл", Price = 150 };
            Product product3 = new Product { Name = "Водка", category = category2, FirmName = "Казаки", Price = 150 };
            Product product4 = new Product { Name = "Хлеб", category = category1, FirmName = "Цесна", Price = 150 };
            Product product5 = new Product { Name = "Кефир", category = category1, FirmName = "Опохмелин", Price = 150 };
            Product product6 = new Product { Name = "Кефир", category = category1, FirmName = "Опохмелин", Price = 150 };
            Product product7 = new Product { Name = "Зефир", category = category1, FirmName = "Порошен", Price = 150 };
            Product product8 = new Product { Name = "Пиво", category = category2, FirmName = "Клинское", Price = 150 };
            Product product9 = new Product { Name = "Спагетти", category = category1, FirmName = "Макаронник", Price = 150 };
            Product product10 = new Product { Name = "Вода", category = category2, FirmName = "Крутой источник", Price = 150 };
            Product product11 = new Product { Name = "Мука", category = category1, FirmName = "Кокос", Price = 150 };
            Product product12 = new Product { Name = "Шампунь", category = category3, FirmName = "Проклят как Гембл", Price = 150 };
            Product product13 = new Product { Name = "Мыло", category = category3, FirmName = "Проклят как Гембл", Price = 150 };
            
            Stok s1 = new Stok { products = product1, ProductCount = 25 };
            Stok s2 = new Stok { products = product2, ProductCount = 35 };
            Stok s3 = new Stok { products = product3, ProductCount = 5 };
            Stok s4 = new Stok { products = product4, ProductCount = 15 };
            Stok s5 = new Stok { products = product5, ProductCount = 40 };
            Stok s6 = new Stok { products = product6, ProductCount = 10 };
            Stok s7 = new Stok { products = product7, ProductCount = 25 };
            Stok s8 = new Stok { products = product8, ProductCount = 25 };
            Stok s9 = new Stok { products = product9, ProductCount = 25 };
            Stok s10 = new Stok { products = product10, ProductCount = 25 };
            Stok s11 = new Stok { products = product11, ProductCount = 25 };
            Stok s12 = new Stok { products = product12, ProductCount = 25 };
            Stok s13 = new Stok { products = product13, ProductCount = 25 };

            using (SalesContext context = new SalesContext())
            {
                context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.Categories.Add(category3);
                context.Categories.Add(category4);

                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Products.Add(product3);
                context.Products.Add(product4);
                context.Products.Add(product5);
                context.Products.Add(product6);
                context.Products.Add(product7);
                context.Products.Add(product8);
                context.Products.Add(product9);
                context.Products.Add(product10);
                context.Products.Add(product11);
                context.Products.Add(product12);
                context.Products.Add(product13);

                context.Stok.Add(s1);
                context.Stok.Add(s2);
                context.Stok.Add(s3);
                context.Stok.Add(s4);
                context.Stok.Add(s5);
                context.Stok.Add(s6);
                context.Stok.Add(s7);
                context.Stok.Add(s8);
                context.Stok.Add(s9);
                context.Stok.Add(s10);
                context.Stok.Add(s11);
                context.Stok.Add(s12);
                context.Stok.Add(s13);

                context.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены в таблицы Categories, Product и Stok");
            }
        }


        private static void Add_Sellers()
        {
            Seller seller1 = new Seller { FullName = "Пендальф Серый" };
            Seller seller2 = new Seller { FullName = "Агент Смитт" };
            Seller seller3 = new Seller { FullName = "Сарумян Мудрый" };

            using (SalesContext context = new SalesContext())
            {
                context.Sellers.Add(seller1);
                context.Sellers.Add(seller2);
                context.Sellers.Add(seller3);
                context.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены в таблицу Seller");
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine("Сделайте свой выбор пожалуйста");
            Console.WriteLine("1 - Зарегистрироваться");
            Console.WriteLine("2 - Посмотреть список товаров");            
            Console.WriteLine("3 - Добавить товар в корзину");
            Console.WriteLine("4 - Посмотреть содержимое корзины");
            Console.WriteLine("5 - Удалить товар из корзины");
            Console.WriteLine("6 - Выход");

        }
    }
}
