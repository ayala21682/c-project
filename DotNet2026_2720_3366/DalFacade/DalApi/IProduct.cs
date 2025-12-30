using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

using DO;
public interface IProduct
{

    int Create(Product product);
    Product? Read(int ProductId);
    List<Product> ReadAll();
    void Update(Product product);
    void Delete(int ProductId);
}

