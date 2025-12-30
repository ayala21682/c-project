using DO;
using DalApi;

namespace Dal;

internal class ProductImplementation:IProduct
{
    public int Create(Product product)
    {
        if (!(DataSource.Products.Exists((pro) => pro.ProductId == product.ProductId)))
            DataSource.Products.Add(product);
        throw new NotImplementedException("product is in the list");
    }
    public Product? Read(int ProductId)
    {
        if (DataSource.Products.Exists((pro) => pro.ProductId == ProductId))
            return DataSource.Products.Find((pro) => pro.ProductId == ProductId);
        throw new NotImplementedException("product is in not the list");
    }
    public List<Product> ReadAll()
    {
        return DataSource.Products;
    }
    public void Update(Product product)
    {
        if (DataSource.Products.Exists((pro) => pro.ProductId == product.ProductId))
            DataSource.Products[DataSource.Products.FindIndex((pro) => pro.ProductId == product.ProductId)] = product;

    }
    public void Delete(int ProductId)
    {
        if (DataSource.Products.Exists((pro) => pro.ProductId == ProductId))
            DataSource.Products.Remove(DataSource.Products.Find((pro) => pro.ProductId == ProductId));
    }
}
