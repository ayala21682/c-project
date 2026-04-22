using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public record Order(bool preferredCustomer, List<ProductInOrder> ProductsOnOrder,double TotalPrice)
    {
        public Order() : this( false,new List<ProductInOrder>(),0.0)
        {

        }
    }
}
