using System.Xml;
using Dal;
using DalApi;
using DO;
using static Dal.DalException;
namespace DalTest
{
    internal class Program
    {

        //private static IDal s_dal = new Dal.DalList();
        private static IDal s_dal =DalXml.Instance;


        static void Main(string[] args)
        {
            try
            {
                Initialization.Initialize(s_dal);
                MainMenu();
            }
            catch (DalIdAlreadyExistsException diaee)
            {
                Console.WriteLine(diaee.Message);
            }
            catch (DalIdNotExistsException dinee)
            {
                Console.WriteLine(dinee.Message);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
        public static void MainMenu()
        {
            Console.WriteLine("choose department");
            Console.WriteLine("for product press 1");
            Console.WriteLine("for customer press 2");
            Console.WriteLine("for Sale press 3");
            Console.WriteLine("to quit press any other key");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            switch(choice)
            {
                case 1: SubMenuProduct(s_dal.Product); break;
                case 2:SubmenuCustomer(s_dal.Customer); break;
                case 3: SubmenuSale(s_dal.Sale); break;
                default:break;

            }
        }
        public static int PrintSubMenu(string name)
        {
            Console.WriteLine($"for returning to the main menu press 0");
            Console.WriteLine($"for viewing all {name}s press 1 ");
            Console.WriteLine($"for getting a specific {name} prees 2");
            Console.WriteLine($"for deleteing a specific {name} press 3");
            Console.WriteLine($"for updating a specific {name} press 4");
            Console.WriteLine($"for creating new {name} press 5");
            Console.WriteLine($"for quitinig press any other key");
           
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        private static void SubMenuProduct(IProduct prod)
        {
            Console.WriteLine("product");
            int choice = PrintSubMenu("product");
            switch (choice)
            {
                case 0: MainMenu(); break;
                case 1: ReadAll(prod); SubMenuProduct(prod);break;
                case 2: Read(prod); SubMenuProduct(prod);break;
                case 3: Delete(prod);SubMenuProduct(prod);break;
                case 4: UpdateProduct(prod);SubMenuProduct(prod);break;
                case 5: AddProduct(prod); SubMenuProduct(prod);break;
                default:break;
              
            }

        }
        private static void SubmenuSale(ISale sale)
        {
            Console.WriteLine("sale");
            int choice = PrintSubMenu("sale");
                        switch (choice)
            {
                case 0: MainMenu(); break;
                case 1: ReadAll(sale); SubmenuSale(sale); break;
                case 2: Read(sale); SubmenuSale(sale); break;
                case 3: Delete(sale); SubmenuSale(sale); break;
                case 4: UpdateSale(sale); SubmenuSale(sale); break;
                case 5: AddSale(sale); SubmenuSale(sale); break;
                default: break;
                     }
        }
        private static void SubmenuCustomer(ICustomer cust)
        {
            Console.WriteLine("customer");
            int choice = PrintSubMenu("customer");
            switch (choice)
            {
                case 0: MainMenu(); break;
                case 1: ReadAll(cust); SubmenuCustomer(cust); break;
                case 2: Read(cust); SubmenuCustomer(cust); break;
                case 3: Delete(cust); SubmenuCustomer(cust); break;
                case 4: UpdateCustomer(cust); SubmenuCustomer(cust); break;
                case 5: AddCustomer(cust); SubmenuCustomer(cust); break;
                default: break;

            }
        }
        private static Product AskProduct(int ProductId=0)
        {
            string name;
            Category category;
            double price;
            int amount;
            Console.WriteLine("insert ProductName:");
             name=Console.ReadLine();
            Console.WriteLine("insert ProductCategorey:");
            int cat;
            if (!int.TryParse(Console.ReadLine(), out cat))
                category = Category.cat5;
            else
                category=(Category)cat;
            Console.WriteLine("insert ProductPrice:");
            if (!double.TryParse(Console.ReadLine(), out price))
                price = 100;

            Console.WriteLine("insert ProductAmount:");
            if (!int.TryParse(Console.ReadLine(), out amount)) 
                amount = 10;
            Product product = new Product(ProductId, name,category,price,amount);
            return product;
        }
        private static Customer AskCustomer(int customerId = 0) {
            string name;
            string address;
            string phoneNumber;
            Console.WriteLine("insert CustomerName:");
            name=Console.ReadLine();
            Console.WriteLine("insert Address:");
            address = Console.ReadLine();
            Console.WriteLine("insert phoneNumber:");
            phoneNumber = Console.ReadLine();

           Customer customer = new Customer(customerId,name,address,phoneNumber);
            return customer;
        }
        private static Sale AskSale(int saleId = 0) {
            int productId;
            int requiredAmount;
            double salePrice;
            bool forAllCustomers;
            DateTime beginSale;
            DateTime endSale;
            Console.WriteLine("insert ProductId:");
            if(!int.TryParse(Console.ReadLine(),out productId))
                productId = 0;
            Console.WriteLine("insert RequiredAmount:");
            if(!int.TryParse(Console.ReadLine(),out requiredAmount))
                requiredAmount = 0;
            Console.WriteLine("insert SalePrice:");
            if(!double.TryParse(Console.ReadLine(),out salePrice))
                salePrice = 0;
            Console.WriteLine("insert ForAllCustomers:");
            if(!bool.TryParse(Console.ReadLine(), out forAllCustomers))
               forAllCustomers = true;
            Console.WriteLine("insert BeginSale:");
            if(!DateTime.TryParse(Console.ReadLine(),out beginSale))
                beginSale = DateTime.Now;
            Console.WriteLine("insert EndSale:");
            if (!DateTime.TryParse(Console.ReadLine(), out endSale))
               endSale = DateTime.Now;
            Sale sale = new Sale(saleId,productId,requiredAmount,salePrice,forAllCustomers,beginSale,endSale);
            return sale;
        }
        private static void AddProduct(IProduct pro)
        {
            Product product = AskProduct();
            pro.Create(product);

        }
        private static void AddSale(ISale sa)
        {
            Sale sale = AskSale();
            sa.Create(sale);
        }
        private static void AddCustomer(ICustomer cus)
        {
            int id;
            Console.WriteLine("insert customer id");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Customer customer = AskCustomer(id);
            cus.Create(customer);
        }
        private static void UpdateProduct(IProduct pro)
        {
            int id;
            Console.WriteLine("insert productId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Product product = AskProduct(id);
            pro.Update(product);

        }
        private static void UpdateSale(ISale sa)
        {
            int id;
            Console.WriteLine("insert saleId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Sale sale = AskSale(id);
            sa.Update(sale);
        }
        private static void UpdateCustomer(ICustomer cus)
        {
            int id;
            Console.WriteLine("insert customerId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Customer customer = AskCustomer(id);
            cus.Update(customer);
        }
        private static void Read<T>(ICrud<T>icrud )
        {
            int id;
            Console.WriteLine("insert Id");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Console.WriteLine(icrud.Read(id));
        }
        private static void ReadAll<T>(ICrud<T> icrud) {
            List<T> list= icrud.ReadAll();
           ReadAll(list);
        }
        private static void ReadAll<T>(List<T> icrud) {
            foreach (T p in icrud)
            {
                Console.WriteLine(p);
            }
        }
        private static void Delete<T>(ICrud<T> icrud)
        {
            int id;
            Console.WriteLine("insert Id");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            icrud.Delete(id);
        } 
    }
}
