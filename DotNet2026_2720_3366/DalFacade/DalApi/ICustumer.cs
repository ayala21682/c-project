

namespace DalApi;

using DO;
public interface ICustumer
{
   public int Create(Customer custumer);
   public Customer? Read(int CustomerId);
   public List<Customer> ReadAll();
   public void Update(Customer custumer);
   public void Delete(int CustomerId);
}