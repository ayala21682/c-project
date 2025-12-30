using System.Xml;
using Dal;
using DalApi;
using DO;
using static Dal.DalException;
namespace DalTest
{
    internal class Program
    {
        private static ICustomer s_dalCustomer = new CustomerImplementation();
        private static ISale s_dalSale = new SaleImplementation();
        private static IProduct s_dalProduct = new ProductImplementation();
        static void Main(string[] args)
        {
            try
            {
                Initialization.Initialize(s_dalCustomer, s_dalSale, s_dalProduct);
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
                case 1: SubMenuProduct(s_dalProduct); break;
                case 2:SubmenuCustomer(s_dalCustomer); break;
                case 3: SubmenuSale(s_dalSale); break;
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
                case 1: ReadAllProduct(prod); SubMenuProduct(prod);break;
                case 2: ReadProduct(prod); SubMenuProduct(prod);break;
                case 3: DeleteProduct(prod);SubMenuProduct(prod);break;
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
                case 1: ReadAllSale(sale); SubmenuSale(sale); break;
                case 2: ReadSale(sale); SubmenuSale(sale); break;
                case 3: DeleteSale(sale); SubmenuSale(sale); break;
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
                case 1: ReadAllCustomer(cust); SubmenuCustomer(cust); break;
                case 2: ReadCustomer(cust); SubmenuCustomer(cust); break;
                case 3: DeleteCustomer(cust); SubmenuCustomer(cust); break;
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
            Customer customer = AskCustomer();
            cus.Create(customer);
        }
        private static void UpdateProduct(IProduct pro)
        {
            Product product = AskProduct();
            pro.Update(product);

        }
        private static void UpdateSale(ISale sa)
        {
            Sale sale = AskSale();
            sa.Update(sale);
        }
        private static void UpdateCustomer(ICustomer cus)
        {
            Customer customer = AskCustomer();
            cus.Update(customer);
        }
        private static void ReadProduct(IProduct pro)
        {
            int id;
            Console.WriteLine("insert productId");
            if(!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Console.WriteLine(pro.Read(id));
        }
        private static void ReadCustomer(ICustomer cus)
        {
            int id;
            Console.WriteLine("insert customerId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Console.WriteLine(cus.Read(id));
        }
        private static void ReadSale(ISale sale)
        {
            int id;
            Console.WriteLine("insert saleId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            Console.WriteLine(sale.Read(id));
        }
        private static void ReadAllProduct(IProduct pro)
        {
            List<Product> product=pro.ReadAll();
           ReadAllProduct(product);                        
        }
        private static void ReadAllCustomer(ICustomer cus)
        {
            List<Customer> customer=cus.ReadAll();
            ReadAllCustomer(customer);
        }
        private static void ReadAllSale(ISale sal) {
            List<Sale> sale=sal.ReadAll();
           ReadAllSale(sale);
        }
        private static void ReadAllProduct(List<Product> pro) {
            foreach (Product p in pro)
            {
                Console.WriteLine(p);
            }
        }
        private static void ReadAllCustomer(List<Customer> cus)
        {
            foreach (Customer c in cus)
            {
                Console.WriteLine(c);
            }
        }
        private static void ReadAllSale(List<Sale> sa)
        {
            foreach (Sale s in sa)
            {
                Console.WriteLine(s);
            }
        }
        private static void DeleteProduct(IProduct product)
        {
            int id;
            Console.WriteLine("insert ProductId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            product.Delete(id);
        }
        private static void DeleteCustomer(ICustomer customer)
        {
            int id;
            Console.WriteLine("insert CustomerId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            customer.Delete(id);
        }
        private static void DeleteSale(ISale sale)
        {
            int id;
            Console.WriteLine("insert SaleId");
            if (!int.TryParse(Console.ReadLine(), out id))
                id = 0;
            sale.Delete(id);
        } 
    }
}
