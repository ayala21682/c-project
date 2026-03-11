
using DalApi;
using DO;

namespace Dal;

internal class DataSource
{
    internal static  List<Sale?> Sales=new();
    internal static  List<Product?> Products=new();
    internal static List<Customer?> Customers=new();

    internal static class Config
    {
       
        internal const int SaleInitialValue=1;
        internal const int ProductInitialValue = 100;
      
        private static int SaleId = SaleInitialValue;
        private static int ProductId = ProductInitialValue;

        public static int GetSaleId =>SaleId++; 
        public static int GetProductId=>ProductId++; 
    }

}
