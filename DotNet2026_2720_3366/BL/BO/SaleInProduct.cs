using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   
    public record SaleInProduct(int SaleId, int AmountForSale, double Price,bool ForAllCustomers)
    {
        public SaleInProduct() : this(0, 0, 0.0, false)
        {

        }
    }
}
