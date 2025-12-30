using DO;
using DalApi;

   namespace Dal;

internal class CustomerImplementation:ICustumer
{
    
    public int Create(Customer custumer)
    {
        if(!(DataSource.Customers.Exists((cus)=>cus.CustomerId==custumer.CustomerId)))
            DataSource.Customers.Add(custumer);
        throw new NotImplementedException("custumer is in the list");
    }
    public Customer? Read(int CustomerId)
    {        
        if(DataSource.Customers.Exists((cus)=>cus.CustomerId ==CustomerId))
            return DataSource.Customers.Find((cus) => cus.CustomerId == CustomerId);
             throw new NotImplementedException("custumer is in not the list");
    }
    public List<Customer> ReadAll()
    {
        return DataSource.Customers;
    }
    public void Update(Customer custumer) {
        if (DataSource.Customers.Exists((cus) => cus.CustomerId == custumer.CustomerId))
            DataSource.Customers[ DataSource.Customers.FindIndex((cus) => cus.CustomerId == custumer.CustomerId)]=custumer;
       
            }
    public void Delete(int CustomerId) {
        if (DataSource.Customers.Exists((cus) => cus.CustomerId == CustomerId))
            DataSource.Customers.Remove(DataSource.Customers.Find((cus) => cus.CustomerId == CustomerId));
    }
}
