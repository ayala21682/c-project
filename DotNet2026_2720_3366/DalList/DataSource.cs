
using DalApi;
using DO;

namespace Dal;

internal class DataSource
{
    internal static  List<Sale> Sales=new();
    internal static  List<Product> Products=new();
    internal static List<Customer> Customers=new();

    internal static  class Config
    {
        internal const int CustomerInitialValue=1000;
        internal const int SaleInitialValue=1;
        internal const int ProductInitialValue = 100;
        private static int CustomerId = CustomerInitialValue;
        private static int SaleId = SaleInitialValue;
        private static int ProductId = ProductInitialValue;
        internal static int GetCustomerId
        { get { return CustomerId++; } }

        internal static int GetSaleId
        { get { return SaleId++; } }

        internal static int GetProductId
        { get { return ProductId++; } }
    }

}
