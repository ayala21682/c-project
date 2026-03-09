using DO;
using DalApi;
using static Dal.DalException;

namespace Dal;

public class ProductImplementation : IProduct
{
    public int Create(Product product)
    {
        //int myId = DataSource.Config.GetProductId;
        //Product product2 = product with { ProductId = myId };
        //DataSource.Products.Add(product2);
        //return product2.ProductId;

        if (!DataSource.Products.Any(p=>p.ProductId==product.ProductId))
        {
            DataSource.Products.Add(product);
            return product.ProductId;
        }

        throw new DalIdAlreadyExistsException("product already exists");
    }
    public Product Read(int id)
    {
        if (DataSource.Products.Exists(pro => pro != null && pro.ProductId == id))
            return DataSource.Products.Find(pro => pro.ProductId == id);
        else
            throw new DalIdNotExistsException("Product is not in the list");
    }
    public Product Read(Func<Product, bool> filter)
    {
        var product = DataSource.Products.FirstOrDefault(filter);

        if (product == null)
            throw new DalIdNotExistsException("Product is not in the list");

        return product;
    }



    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        var query = DataSource.Products.AsEnumerable();
        if (filter != null)
            query = query.Where(filter);
        return query.ToList();
    }
    public void Update(Product product)
    {
        Delete(product.ProductId);
        DataSource.Products.Add(product);
    }
    public void Delete(int ProductId)
    {
        //if (DataSource.Products.Exists((pro) => pro.ProductId == ProductId))
        //    DataSource.Products.Remove(DataSource.Products.Find((pro) => pro.ProductId == ProductId));
        //else
        //    throw new DalIdNotExistsException("product is in not the list");
        var product = DataSource.Products.FirstOrDefault(p=>p.ProductId== ProductId);
        if (product == null)
            throw new DalIdNotExistsException("Product is not in the list");

        DataSource.Products.Remove(product);
    }
}
