using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalList:IDal
    {
        public  IProduct Product=>new ProductImplementation();
        public ICustomer Customer=>new CustomerImplementation();
        public ISale Sale=>new SaleImplementation();    
    }
}
