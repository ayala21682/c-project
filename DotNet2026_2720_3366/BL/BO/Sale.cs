using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public record Sale(int SaleId, int ProductId, int RequiredAmount, double SalePrice, bool ForAllCustomers, DateTime BeginSale, DateTime EndSale)
    {
        public Sale() : this(0, 0, 0, 0, false, DateTime.Now, DateTime.Now)
        {

        }
    }
}
