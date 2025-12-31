using DO;
using DalApi;
using static Dal.DalException;

namespace Dal;

public class ProductImplementation:IProduct
{
    public int Create(Product product)
    {
       int myId = DataSource.Config.GetProductId;
       Product product2 =product with { ProductId=myId };
       DataSource.Products.Add(product2);
       return product2.ProductId;   
        
    }
    public Product? Read(int ProductId)
    {
        if (DataSource.Products.Exists((pro) => pro.ProductId == ProductId))
            return DataSource.Products.Find((pro) => pro.ProductId == ProductId);
        throw new DalIdNotExistsException("product is in not the list");        
    }
    public List<Product> ReadAll()
    {
        List<Product> product2 = new List<Product>(DataSource.Products);
        return product2;
    }
    public void Update(Product product)
    {
        Delete(product.ProductId);
        DataSource.Products.Add(product);
    }
    public void Delete(int ProductId)
    {
        if (DataSource.Products.Exists((pro) => pro.ProductId == ProductId))
            DataSource.Products.Remove(DataSource.Products.Find((pro) => pro.ProductId == ProductId));
        else
            throw new DalIdNotExistsException("product is in not the list");
    }
}
