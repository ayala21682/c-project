

namespace DalApi;

using DO;
public interface ICustomer:ICrud<Customer>
{
    public int Create(Customer item);
    public Customer? Read(int id);
    public Customer? Read(Func<Customer, bool> filter);
    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null);
    public List<Customer?> ReadAll();
    public void Update(Customer item);
    public void Delete(int itemId);
    //global::BO.Customer? Read(Func<global::BO.Customer, bool> filter);
}