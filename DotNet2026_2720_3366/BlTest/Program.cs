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
using DO;
using static BO.BlException;

namespace BlTest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        private static Order currentOrder = new Order { ProductsOnOrder = new List<ProductInOrder>() };

        static void Main(string[] args)
        {
            try
            {
                DalTest.Initialization.Initialize();
                MainMenu();
            }
            catch (BlIdAlreadyExistsException biaee)
            {
                Console.WriteLine(biaee.Message);
            }
            catch (BlIdNotExistsException binee)
            {
                Console.WriteLine(binee.Message);
            }
            catch (BlNoProductInStock bnpis)
            {
                Console.WriteLine(bnpis.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("choose department");
                Console.WriteLine("for product press 1");
                Console.WriteLine("for customer press 2");
                Console.WriteLine("for Sale press 3");
                Console.WriteLine("for Order Actions press 4");
                Console.WriteLine("to quit press 0");

                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1: SubMenuProduct(); break;
                    case 2: SubmenuCustomer(); break;
                    case 3: SubmenuSale(); break;
                    case 4: SubmenuOrder(); break;
                    default: break;
                }
            } while (choice != 0);
        }

        public static int PrintSubMenu(string name)
        {
            Console.WriteLine($"for returning to the main menu press 0");
            Console.WriteLine($"for viewing all {name}s press 1 ");
            Console.WriteLine($"for getting a specific {name} press 2");
            Console.WriteLine($"for deleting a specific {name} press 3");
            Console.WriteLine($"for updating a specific {name} press 4");
            Console.WriteLine($"for creating new {name} press 5");

            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }

        private static void SubMenuProduct()
        {
            Console.WriteLine("product");
            int choice = PrintSubMenu("product");
            switch (choice)
            {
                case 1: ReadAll(s_bl.Product.ReadAll().ToList()); break;
                case 2:
                    Console.WriteLine("insert Id");
                    int.TryParse(Console.ReadLine(), out int id);
                    Console.WriteLine(s_bl.Product.Read(id));
                    break;
                case 3:
                    Console.WriteLine("insert Id");
                    int.TryParse(Console.ReadLine(), out int delId);
                    s_bl.Product.Delete(delId);
                    break;
                case 4:
                    Console.WriteLine("insert productId");
                    int.TryParse(Console.ReadLine(), out int upId);
                    s_bl.Product.Update(AskProduct(upId));
                    break;
                case 5:
                    s_bl.Product.Create(AskProduct());
                    break;
                default: break;
            }
        }

        private static void SubmenuSale()
        {
            Console.WriteLine("sale");
            int choice = PrintSubMenu("sale");
            switch (choice)
            {
                case 1: ReadAll(s_bl.Sale.ReadAll().ToList()); break;
                case 2:
                    Console.WriteLine("insert Id");
                    int.TryParse(Console.ReadLine(), out int id);
                    Console.WriteLine(s_bl.Sale.Read(id));
                    break;
                case 3:
                    Console.WriteLine("insert Id");
                    int.TryParse(Console.ReadLine(), out int delId);
                    s_bl.Sale.Delete(delId);
                    break;
                case 4:
                    Console.WriteLine("insert saleId");
                    int.TryParse(Console.ReadLine(), out int upId);
                    s_bl.Sale.Update(AskSale(upId));
                    break;
                case 5:
                    s_bl.Sale.Create(AskSale());
                    break;
                default: break;
            }
        }

        private static void SubmenuCustomer()
        {
            Console.WriteLine("customer");
            int choice = PrintSubMenu("customer");
            switch (choice)
            {
                case 1: ReadAll(s_bl.Customer.ReadAll().ToList()); break;
                case 2:
                    Console.WriteLine("insert Id");
                    int.TryParse(Console.ReadLine(), out int id);
                    Console.WriteLine(s_bl.Customer.Read(id));
                    break;
                case 3:
                    Console.WriteLine("insert Id");
                    int.TryParse(Console.ReadLine(), out int delId);
                    s_bl.Customer.Delete(delId);
                    break;
                case 4:
                    Console.WriteLine("insert customerId");
                    int.TryParse(Console.ReadLine(), out int upId);
                    s_bl.Customer.Update(AskCustomer(upId));
                    break;
                case 5:
                    Console.WriteLine("insert customerId");
                    int.TryParse(Console.ReadLine(), out int newId);
                    s_bl.Customer.Create(AskCustomer(newId));
                    break;
                default: break;
            }
        }

        private static void SubmenuOrder()
        {
            Console.WriteLine("Order Actions");
            Console.WriteLine("for returning to main menu press 0");
            Console.WriteLine("for adding product to current order press 1");
            Console.WriteLine("for submitting the final order press 2");
            Console.WriteLine("for displaying current order details press 3");

            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Is this a preferred customer? (true/false):");
                    bool.TryParse(Console.ReadLine(), out bool isPrefered);
                    currentOrder = currentOrder with { preferredCustomer = isPrefered };

                    Console.WriteLine("insert ProductId:");
                    int.TryParse(Console.ReadLine(), out int prodId);
                    Console.WriteLine("insert Amount:");
                    int.TryParse(Console.ReadLine(), out int amount);

                    var sales = s_bl.Order.AddProductToOrder(currentOrder, prodId, amount);
                    Console.WriteLine("Product added successfully.");
                    break;

                case 2:
                    s_bl.Order.DoOrder(currentOrder);
                    Console.WriteLine("Order processed and stock updated successfully.");
                    currentOrder = new Order { ProductsOnOrder = new List<ProductInOrder>() };
                    break;

                case 3:
                    Console.WriteLine($"Preferred Customer: {currentOrder.preferredCustomer}");
                    Console.WriteLine($"Total Order Price: {currentOrder.TotalPrice}");
                    Console.WriteLine("Products in order:");
                    ReadAll(currentOrder.ProductsOnOrder);
                    break;

                default: break;
            }
        }

        private static BO.Product AskProduct(int ProductId = 0)
        {
            Console.WriteLine("insert ProductName:");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("insert ProductCategorey (0-4):");
            int.TryParse(Console.ReadLine(), out int cat);
            Category category = (Category)cat;
            Console.WriteLine("insert ProductPrice:");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine("insert ProductAmount:");
            int.TryParse(Console.ReadLine(), out int amount);

            return new BO.Product
            {
                ProductId = ProductId,
                ProductName = name,
                ProductCategorey = category,
                Price = price,
                Amount = amount,
                ListOfSales = new List<SaleInProduct>()
            };
        }

        private static BO.Customer AskCustomer(int customerId = 0)
        {
            Console.WriteLine("insert CustomerName:");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("insert Address:");
            string address = Console.ReadLine() ?? "";
            Console.WriteLine("insert phoneNumber:");
            string phoneNumber = Console.ReadLine() ?? "";

            return new BO.Customer
            {
                CustomerId = customerId,
                CustomerName = name,
                Address = address,
                PhoneNumber = phoneNumber
            };
        }

        private static BO.Sale AskSale(int saleId = 0)
        {
            Console.WriteLine("insert ProductId:");
            int.TryParse(Console.ReadLine(), out int productId);
            Console.WriteLine("insert RequiredAmount:");
            int.TryParse(Console.ReadLine(), out int requiredAmount);
            Console.WriteLine("insert SalePrice:");
            double.TryParse(Console.ReadLine(), out double salePrice);
            Console.WriteLine("insert ForAllCustomers (true/false):");
            bool.TryParse(Console.ReadLine(), out bool forAllCustomers);
            Console.WriteLine("insert BeginSale (yyyy-MM-dd):");
            DateTime.TryParse(Console.ReadLine(), out DateTime beginSale);
            Console.WriteLine("insert EndSale (yyyy-MM-dd):");
            DateTime.TryParse(Console.ReadLine(), out DateTime endSale);

            return new BO.Sale
            {
                SaleId = saleId,
                ProductId = productId,
                RequiredAmount = requiredAmount,
                SalePrice = salePrice,
                ForAllCustomers = forAllCustomers,
                BeginSale = beginSale,
                EndSale = endSale
            };
        }

        private static void ReadAll<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}