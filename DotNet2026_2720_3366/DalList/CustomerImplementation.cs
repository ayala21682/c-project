using DO;
using DalApi;
using static Dal.DalException;

namespace Dal;

public class CustomerImplementation : ICustomer
{

    public int Create(Customer customer)
    {
        //if (!(DataSource.Customers.Exists((cus) => cus.CustomerId == custumer.CustomerId)))
        //{
        //    DataSource.Customers.Add(custumer);
        //    return custumer.CustomerId;
        //}
        //throw new DalIdAlreadyExistsException("Customer already Exist");

        if (!DataSource.Customers.Any(c => c.CustomerId == customer.CustomerId))
        {
            DataSource.Customers.Add(customer);
            return customer.CustomerId;
        }

        throw new DalIdAlreadyExistsException("Customer already exists");

    }
    public Customer Read(int id)
    {
        if (DataSource.Customers.Exists(cus => cus != null && cus.CustomerId == id))
            return DataSource.Customers.Find(cus => cus.CustomerId == id);
        else
            throw new DalIdNotExistsException("Customer is not in the list");
    }

    public Customer Read(Func<Customer, bool> filter)
    {
        var customer = DataSource.Customers.FirstOrDefault(filter);

        if (customer == null)
            throw new DalIdNotExistsException("Customer is not in the list");

        return customer;
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        var query = DataSource.Customers.AsEnumerable();
        if (filter != null)
            query = query.Where(filter);
        return query.ToList();
    }
    public List<Customer> ReadAll()
    {
        return DataSource.Customers.ToList();
    }
    public void Update(Customer custumer)
    {
        Delete(custumer.CustomerId);
        DataSource.Customers.Add(custumer);
    }
    public void Delete(int CustomerId)
    {
        {
            //if (DataSource.Customers.Exists((cus) => cus.CustomerId == CustomerId))
            //    DataSource.Customers.Remove(DataSource.Customers.Find((cus) => cus.CustomerId == CustomerId)!);
            //else
            //    throw new DalIdNotExistsException("custumer is in not the list");
            var customer = DataSource.Customers.FirstOrDefault(c => c.CustomerId == CustomerId);
            if (customer == null)
                throw new DalIdNotExistsException("Customer is not in the list");
            DataSource.Customers.Remove(customer);

        }
    }
}