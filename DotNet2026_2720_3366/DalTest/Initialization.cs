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

   public static List<int> productlist=new List<int>();
    private static void createProduct()
    {      
        productlist.Add(s_dal.Product.Create(new Product(5, "chair", Category.cat2, 52.8, 77)));
        productlist.Add(s_dal.Product.Create(new Product(4, "desk", Category.cat3, 255.8, 7)));
        productlist.Add(s_dal.Product.Create(new Product(3, "table", Category.cat1, 2212.6668, 8)));
        productlist.Add(s_dal.Product.Create(new Product(2, "sofa", Category.cat5, 2444.558, 8)));
        productlist.Add(s_dal.Product.Create(new Product(2, "bed", Category.cat4, 245.8, 122)));
        
    }



    private static void createSale()
    {

        s_dal.Sale.Create(new Sale(5, productlist[0], 4, 22.5, false, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(4, productlist[1], 4, 22.5, true, DateTime.Now, DateTime.Now.AddDays(5)));
        s_dal.Sale.Create(new Sale(3, productlist[2], 4, 22.5, false, DateTime.Now, DateTime.Now.AddDays(60)));
        s_dal.Sale.Create(new Sale(2, productlist[3], 4, 22.5, true, DateTime.Now, DateTime.Now.AddDays(100)));
        s_dal.Sale.Create(new Sale(1, productlist[4], 4, 22.5, false, DateTime.Now, DateTime.Now.AddDays(15)));

    }
    public static void Initialize(IDal s_dalf)
    {
        s_dal = s_dalf;
        
        createCustomer();
        createProduct();
        createSale();
    }
}
