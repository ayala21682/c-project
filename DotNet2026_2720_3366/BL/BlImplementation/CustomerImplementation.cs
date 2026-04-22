using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class CustomerImplementation:BlApi.ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(Customer item)
        {
            return _dal.Customer.Create(item.ConvertBOCustomerToDOCustomer());
        }

        public void Delete(int itemId)
        {
            _dal.Customer.Delete(itemId);
        }

        public bool IsCustomerExist(Customer item)
        {
            var customer = _dal.Customer.Read(item.CustomerId);
            return customer != null;
        }

        public Customer? Read(int id)
        {
            return _dal.Customer.Read(id).ConvertDOCustomerToBOCustomer();
        }

        public Customer? Read(Func<BO.Customer, bool> filter)
        {
            return _dal.Customer.ReadAll()
                .Select(c => c.ConvertDOCustomerToBOCustomer())
                .FirstOrDefault(filter);
        }

        public List<Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
        {

            var list = _dal.Customer.ReadAll().Select(p => p.ConvertDOCustomerToBOCustomer());
            if (filter != null) 
                list=list.Where(filter);
            return list.ToList()!;

        }

        public List<Customer?> ReadAll()
        {
            var list = _dal.Customer.ReadAll();
            return list.Select(c=>c.ConvertDOCustomerToBOCustomer()).ToList()!;
            

        }

        public void Update(Customer item)
        {
            _dal.Customer.Update(item.ConvertBOCustomerToDOCustomer());
        }
    }
}
