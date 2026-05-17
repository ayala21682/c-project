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
        public ISale Sale { get; }= new SaleImplementation();

        public IProduct Product { get; } = new ProductImplementation();

        public ICustomer Customer { get; } = new CustomerImplementation();

        public IOrder Order { get; } = new OrderImplementation();

       
    }
}
