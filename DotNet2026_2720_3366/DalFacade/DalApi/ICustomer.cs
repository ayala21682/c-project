

namespace DalApi;

using DO;
public interface ICustomer
{
   public int Create(Customer custumer);
   public Customer? Read(int CustomerId);
   public List<Customer> ReadAll();
   public void Update(Customer custumer);
   public void Delete(int CustomerId);
}