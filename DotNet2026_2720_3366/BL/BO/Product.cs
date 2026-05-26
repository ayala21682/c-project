using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public record Product(int ProductId, string ProductName, Category ProductCategorey, double Price, int Amount, List<SaleInProduct> ListOfSales)
    {
        public Product() : this(0, "", Category.Face, 0, 0,new List<SaleInProduct>())
        {

        }
    }
}
