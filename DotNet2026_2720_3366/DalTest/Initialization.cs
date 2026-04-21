using DO;
using DalApi;
using Dal;
namespace DalTest;

public static class Initialization
{
    //private static ICustomer? s_dalCustomer;
    //private static ISale? s_dalSale;
    //private static IProduct? s_dalProduct;
    private static IDal? s_dal;
    private static void createCustomer()
    {
        s_dal.Customer.Create(new Customer(1, "Alice Cohen", "Tel Aviv", "050-1234567"));
        s_dal.Customer.Create(new Customer(2, "David Levi", "Jerusalem", null));
        s_dal.Customer.Create(new Customer(3, "Maya Shapiro", null, "052-7654321"));
        s_dal.Customer.Create(new Customer(4, "Noam Katz", "Haifa", "054-1112233"));
        s_dal.Customer.Create(new Customer(5, "Elior Ben David", null, null));
    }

  
    private static void createProduct()
    {      
        s_dal.Product.Create(new Product(5, "chair", Category.cat2, 52.8, 77));
       s_dal.Product.Create(new Product(4, "desk", Category.cat3, 255.8, 7));
        s_dal.Product.Create(new Product(3, "table", Category.cat1, 2212.6668, 8));
        s_dal.Product.Create(new Product(2, "sofa", Category.cat5, 2444.558, 8));


        
    }



    private static void createSale()
    {

        s_dal.Sale.Create(new Sale(5, s_dal.Product.Read(101).ProductId, 4, 22.5, false, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(4, s_dal.Product.Read(101).ProductId, 4, 22.5, true, DateTime.Now, DateTime.Now.AddDays(5)));
        s_dal.Sale.Create(new Sale(3, s_dal.Product.Read(102).ProductId, 4, 22.5, false, DateTime.Now, DateTime.Now.AddDays(60)));
        s_dal.Sale.Create(new Sale(2, s_dal.Product.Read(101).ProductId, 4, 22.5, true, DateTime.Now, DateTime.Now.AddDays(100)));
       

    }
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        createProduct();
        createSale();
        createCustomer();

    }
}
