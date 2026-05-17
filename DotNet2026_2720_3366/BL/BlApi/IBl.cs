using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        public ISale Sale { get; }
        public IProduct Product { get; }
        public ICustomer Customer { get; }
        public IOrder Order { get; }
    }
}
