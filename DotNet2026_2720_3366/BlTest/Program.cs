//using System.Xml;
//using Dal;
//using DalApi;
//using DO;
//using static Dal.DalException;
//namespace DalTest
//{
//    internal class Program
//    {

//        //private static IDal s_dal = new Dal.DalList();
//        private static IDal s_dal = DalApi.Factory.Get;


//        static void Main(string[] args)
//        {
//            try
//            {
//                Initialization.Initialize();
//                MainMenu();
//            }
//            catch (DalIdAlreadyExistsException diaee)
//            {
//                Console.WriteLine(diaee.Message);
//            }
//            catch (DalIdNotExistsException dinee)
//            {
//                Console.WriteLine(dinee.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//        public static void MainMenu()
//        {
//            Console.WriteLine("choose department");
//            Console.WriteLine("for product press 1");
//            Console.WriteLine("for customer press 2");
//            Console.WriteLine("for Sale press 3");
//            Console.WriteLine("to quit press any other key");
//            int choice;
//            int.TryParse(Console.ReadLine(), out choice);
//            switch (choice)
//            {
//                case 1: SubMenuProduct(); break;
//                case 2: SubmenuCustomer(); break;
//                case 3: SubmenuSale(); break;
//                default: break;

//            }
//        }
//        public static int PrintSubMenu(string name)
//        {
//            Console.WriteLine($"for returning to the main menu press 0");
//            Console.WriteLine($"for viewing all {name}s press 1 ");
//            Console.WriteLine($"for getting a specific {name} prees 2");
//            Console.WriteLine($"for deleteing a specific {name} press 3");
//            Console.WriteLine($"for updating a specific {name} press 4");
//            Console.WriteLine($"for creating new {name} press 5");
//            Console.WriteLine($"for quitinig press any other key");

//            int choice;
//            int.TryParse(Console.ReadLine(), out choice);
//            return choice;
//        }
//        private static void SubMenuProduct()
//        {
//            Console.WriteLine("product");
//            int choice = PrintSubMenu("product");
//            switch (choice)
//            {
//                case 0: MainMenu(); break;
//                case 1: ReadAll<Product>(s_dal.Product); SubMenuProduct(); break;
//                case 2: Read<Product>(s_dal.Product); SubMenuProduct(); break;
//                case 3: Delete<Product>(s_dal.Product); SubMenuProduct(); break;
//                case 4: UpdateProduct(s_dal.Product); SubMenuProduct(); break;
//                case 5: AddProduct(s_dal.Product); SubMenuProduct(); break;
//                default: break;

//            }

//        }
//        private static void SubmenuSale()
//        {
//            Console.WriteLine("sale");
//            int choice = PrintSubMenu("sale");
//            switch (choice)
//            {
//                case 0: MainMenu(); break;
//                case 1: ReadAll<Sale>(s_dal.Sale); SubmenuSale(); break;
//                case 2: Read<Sale>(s_dal.Sale); SubmenuSale(); break;
//                case 3: Delete<Sale>(s_dal.Sale); SubmenuSale(); break;
//                case 4: UpdateSale(s_dal.Sale); SubmenuSale(); break;
//                case 5: AddSale(s_dal.Sale); SubmenuSale(); break;
//                default: break;
//            }
//        }
//        private static void SubmenuCustomer()
//        {
//            Console.WriteLine("customer");
//            int choice = PrintSubMenu("customer");
//            switch (choice)
//            {
//                case 0: MainMenu(); break;
//                case 1: ReadAll<Customer>(s_dal.Customer); SubmenuCustomer(); break;
//                case 2: Read<Customer>(s_dal.Customer); SubmenuCustomer(); break;
//                case 3: Delete<Customer>(s_dal.Customer); SubmenuCustomer(); break;
//                case 4: UpdateCustomer(s_dal.Customer); SubmenuCustomer(); break;
//                case 5: AddCustomer(s_dal.Customer); SubmenuCustomer(); break;
//                default: break;

//            }
//        }
//        private static Product AskProduct(int ProductId = 0)
//        {
//            string name;
//            Category category;
//            double price;
//            int amount;
//            Console.WriteLine("insert ProductName:");
//            name = Console.ReadLine();
//            Console.WriteLine("insert ProductCategorey:");
//            int cat;
//            if (!int.TryParse(Console.ReadLine(), out cat))
//                category = Category.cat5;
//            else
//                category = (Category)cat;
//            Console.WriteLine("insert ProductPrice:");
//            if (!double.TryParse(Console.ReadLine(), out price))
//                price = 100;

//            Console.WriteLine("insert ProductAmount:");
//            if (!int.TryParse(Console.ReadLine(), out amount))
//                amount = 10;
//            Product product = new Product(ProductId, name, category, price, amount);
//            return product;
//        }
//        private static Customer AskCustomer(int customerId = 0)
//        {
//            string name;
//            string address;
//            string phoneNumber;
//            Console.WriteLine("insert CustomerName:");
//            name = Console.ReadLine();
//            Console.WriteLine("insert Address:");
//            address = Console.ReadLine();
//            Console.WriteLine("insert phoneNumber:");
//            phoneNumber = Console.ReadLine();

//            Customer customer = new Customer(customerId, name, address, phoneNumber);
//            return customer;
//        }
//        private static Sale AskSale(int saleId = 0)
//        {
//            int productId;
//            int requiredAmount;
//            double salePrice;
//            bool forAllCustomers;
//            DateTime beginSale;
//            DateTime endSale;
//            Console.WriteLine("insert ProductId:");
//            if (!int.TryParse(Console.ReadLine(), out productId))
//                productId = 0;
//            Console.WriteLine("insert RequiredAmount:");
//            if (!int.TryParse(Console.ReadLine(), out requiredAmount))
//                requiredAmount = 0;
//            Console.WriteLine("insert SalePrice:");
//            if (!double.TryParse(Console.ReadLine(), out salePrice))
//                salePrice = 0;
//            Console.WriteLine("insert ForAllCustomers:");
//            if (!bool.TryParse(Console.ReadLine(), out forAllCustomers))
//                forAllCustomers = true;
//            Console.WriteLine("insert BeginSale:");
//            if (!DateTime.TryParse(Console.ReadLine(), out beginSale))
//                beginSale = DateTime.Now;
//            Console.WriteLine("insert EndSale:");
//            if (!DateTime.TryParse(Console.ReadLine(), out endSale))
//                endSale = DateTime.Now;
//            Sale sale = new Sale(saleId, productId, requiredAmount, salePrice, forAllCustomers, beginSale, endSale);
//            return sale;
//        }
//        private static void AddProduct(IProduct pro)
//        {
//            Product product = AskProduct();
//            pro.Create(product);

//        }
//        private static void AddSale(ISale sa)
//        {
//            Sale sale = AskSale();
//            sa.Create(sale);
//        }
//        private static void AddCustomer(ICustomer cus)
//        {
//            int id;
//            Console.WriteLine("insert customer id");
//            if (!int.TryParse(Console.ReadLine(), out id))
//                id = 0;
//            Customer customer = AskCustomer(id);
//            cus.Create(customer);
//        }
//        private static void UpdateProduct(IProduct pro)
//        {
//            int id;
//            Console.WriteLine("insert productId");
//            if (!int.TryParse(Console.ReadLine(), out id))
//                id = 0;
//            Product product = AskProduct(id);
//            pro.Update(product);

//        }
//        private static void UpdateSale(ISale sa)
//        {
//            int id;
//            Console.WriteLine("insert saleId");
//            if (!int.TryParse(Console.ReadLine(), out id))
//                id = 0;
//            Sale sale = AskSale(id);
//            sa.Update(sale);
//        }
//        private static void UpdateCustomer(ICustomer cus)
//        {
//            int id;
//            Console.WriteLine("insert customerId");
//            if (!int.TryParse(Console.ReadLine(), out id))
//                id = 0;
//            Customer customer = AskCustomer(id);
//            cus.Update(customer);
//        }
//        private static void Read<T>(ICrud<T> icrud)
//        {
//            int id;
//            Console.WriteLine("insert Id");
//            if (!int.TryParse(Console.ReadLine(), out id))
//                id = 0;
//            Console.WriteLine(icrud.Read(id));
//        }
//        private static void ReadAll<T>(ICrud<T> icrud)
//        {
//            List<T> list = icrud.ReadAll();
//            ReadAll(list);
//        }
//        private static void ReadAll<T>(List<T> icrud)
//        {
//            foreach (T p in icrud)
//            {
//                Console.WriteLine(p);
//            }
//        }
//        private static void Delete<T>(ICrud<T> icrud)
//        {
//            int id;
//            Console.WriteLine("insert Id");
//            if (!int.TryParse(Console.ReadLine(), out id))
//                id = 0;
//            icrud.Delete(id);
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using BO;
using static BO.BlException;

namespace BlTest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        static void Main(string[] args)
        {
            try
            {
                DalTest.Initialization.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Initialization failed: " + ex.Message);
            }

            Console.WriteLine("Hello customer!");

            Console.WriteLine("Insert customer ID:");
            int customerId = int.Parse(Console.ReadLine());

            try
            {
                var customer = s_bl.Customer.Read(customerId);
                if (customer == null)
                {
                    Console.WriteLine("The customer does not exist.");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The customer does not exist.");
                return;
            }

            Console.WriteLine("Are you a club member?");
            Console.WriteLine("1 - Yes");
            Console.WriteLine("0 - No");

            bool club = Console.ReadLine() == "1";

            Order order = new Order()
            {
                preferredCustomer = club,
                ProductsOnOrder = new List<ProductInOrder>(),
                TotalPrice = 0
            };

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== Order Menu =====");
                Console.WriteLine("1 - Adding a product to an order");
                Console.WriteLine("2 - Show order");
                Console.WriteLine("3 - Final price");
                Console.WriteLine("4 - Placing an order");
                Console.WriteLine("0 - Exit");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Insert productId:");
                            int productId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Insert amount:");
                            int amount = int.Parse(Console.ReadLine());

                            // 1. הוספת המוצר וקבלת המבצעים
                            var sales = s_bl.Order.AddProductToOrder(order, productId, amount);

                            // 2. עדכון ה-TotalPrice של ה-order אצלנו ב-Program באמצעות ref
                            s_bl.Order.CalcTotalPrice(ref order);

                            Console.WriteLine("The product has been added to the order.");

                            if (sales != null && sales.Count > 0)
                            {
                                Console.WriteLine("Deals found:");
                                foreach (var sale in sales)
                                {
                                    Console.WriteLine($"Sale ID: {sale.SaleId}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There are no promotions for this product.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("===== Order =====");

                        if (order.ProductsOnOrder == null || order.ProductsOnOrder.Count == 0)
                        {
                            Console.WriteLine("No products in the order");
                            break;
                        }

                        foreach (var item in order.ProductsOnOrder)
                        {
                            Console.WriteLine($"Product ID: {item.ProductId}");
                            Console.WriteLine($"Product Name: {item.ProductName}");
                            Console.WriteLine($"Quantity: {item.AmountInOrder}");
                            Console.WriteLine($"BasePrice: {item.BasicPrice}");
                            Console.WriteLine($"FinalPrice: {item.TotalPrice}");

                            Console.WriteLine("Sales:");
                            if (item.ListOfSales != null)
                            {
                                foreach (var sale in item.ListOfSales)
                                {
                                    Console.WriteLine($"Sale ID: {sale.SaleId}");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Final price for the order: {order.TotalPrice}");
                        break;

                    case 4:
                        try
                        {
                            s_bl.Order.DoOrder(order);
                            Console.WriteLine("The order was placed successfully.");
                            order = new Order()
                            {
                                preferredCustomer = club,
                                ProductsOnOrder = new List<ProductInOrder>(),
                                TotalPrice = 0
                            };
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Incorrect choice");
                        break;
                }

            } while (choice != 0);
        }
    }
}