using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
 
    public record Product(int ProductId, string ProductName, Category ProductCategorey, double Price, int Amount)
    {
        public Product() : this(0, "", Category.cat3, 0, 0)
        {

        }
    }
}
