using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(int ProductId, string ProductName, Enum ProductCategorey, double Price, int Amount)
    {
        public Product() : this(0, "", null, 0, 0)
        {

        }
    }
}
