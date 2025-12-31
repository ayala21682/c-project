using DO;
using DalApi;
using static Dal.DalException;

namespace Dal;

public class CustomerImplementation: ICustomer
{
    
    public int Create(Customer custumer)
    {
        if (!(DataSource.Customers.Exists((cus) => cus.CustomerId == custumer.CustomerId)))
        {
            DataSource.Customers.Add(custumer);
            return custumer.CustomerId;
        }
        throw new DalIdAlreadyExistsException("Customer already Exist");
    }
    public Customer? Read(int CustomerId)
    {        
        if(DataSource.Customers.Exists((cus)=>cus.CustomerId ==CustomerId))
            return DataSource.Customers.Find((cus) => cus.CustomerId == CustomerId);
        else
            throw new DalIdNotExistsException("custumer is in not the list");
    }
    public List<Customer> ReadAll()
    {
        List<Customer> customers2 = new List<Customer>(DataSource.Customers);
        return customers2;
    }
    public void Update(Customer custumer) {
       Delete(custumer.CustomerId);
       DataSource.Customers.Add(custumer);
    }
    public void Delete(int CustomerId) {
        if (DataSource.Customers.Exists((cus) => cus.CustomerId == CustomerId))
            DataSource.Customers.Remove(DataSource.Customers.Find((cus) => cus.CustomerId == CustomerId)!);
        else
            throw new DalIdNotExistsException("custumer is in not the list");

    }
}
