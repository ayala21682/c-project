using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface ICustomer
    {
        public int Create(BO.Customer item);
        public BO.Customer? Read(int id);
        public BO.Customer? Read(Func<BO.Customer, bool> filter);
        public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null);
        public List<BO.Customer?> ReadAll();
        public void Update(BO.Customer item);
        public void Delete(int itemId);

        public bool IsCustomerExist(BO.Customer item);
    }
}
