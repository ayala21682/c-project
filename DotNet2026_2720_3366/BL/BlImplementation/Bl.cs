using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class Bl : BlApi.IBl
    {
        public ISale isale { get; }= new SaleImplementation();

        public IProduct iproduct { get; } = new ProductImplementation();

        public ICustomer icustomer { get; } = new CustomerImplementation();

        public IOrder iorder { get; } = new OrderImplementation();
    }
}
