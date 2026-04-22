using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        public ISale isale { get; }
        public IProduct iproduct { get; }
        public ICustomer icustomer { get; }
        public IOrder iorder { get; }
    }
}
