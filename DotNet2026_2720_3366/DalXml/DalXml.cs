using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal
{
    public sealed class DalXml : IDal
    {
       

        private DalXml()
        {
                
        }
        private static DalXml instance { get; } = new DalXml();
        public static DalXml Instance { get { return instance; } }

        public IProduct Product => new ProductImplementation();
        public ICustomer Customer => new CustomerImplementation();
        public ISale Sale => new SaleImplementation();

    }
}
