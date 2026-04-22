using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
    public record ProductInOrder(int ProductId, string ProductName, double BasicPrice, int AmountInOrder, List<SaleInProduct> ListOfSales,double TotalPrice=0)
    {
        public ProductInOrder() : this(0, "", 0.0, 0, new List<SaleInProduct>(),0.0)
        {

        }
    }
}
