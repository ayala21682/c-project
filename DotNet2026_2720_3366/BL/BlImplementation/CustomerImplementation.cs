using BlApi;
using BO;
using Dal;
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

    
        public int Create(BO.Customer customer)
        {
          
            if (customer.CustomerId <= 0)
            {
                throw new ArgumentException("תעודת זהות חייבת להיות מספר חיובי גדול מ-0.");
            }
            var existingCustomer = _dal.Customer.Read(customer.CustomerId);
            if (existingCustomer != null)
            {
                throw new DalException.DalIdAlreadyExistsException($"שגיאה: לקוח עם תעודת זהות {customer.CustomerId} כבר קיים במערכת!");
            }
            DO.Customer doCustomer = Tools.ConvertBOCustomerToDOCustomer(customer);
            return _dal.Customer.Create(doCustomer);
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
