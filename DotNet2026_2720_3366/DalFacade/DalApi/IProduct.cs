using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

using DO;
public interface IProduct : ICrud<Product>
{
    public int Create(Product item);
    public Product? Read(int id);
    public Product? Read(Func<Product, bool> filter);
    public List<Product?> ReadAll(Func<Product, bool>? filter = null);
    public List<Product?> ReadAll();
    public void Update(Product item);
    public void Delete(int itemId);
}
