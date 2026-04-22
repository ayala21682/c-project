using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlApi
{
    public interface IProduct
    {
        public int Create(BO.Product item);
        public BO.Product? Read(int id);
        public BO.Product? Read(Func<BO.Product, bool> filter);
        public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null);
        public List<BO.Product?> ReadAll();
        public void Update(BO.Product item);
        public void Delete(int itemId);

        public void SalesOnProduct(BO.ProductInOrder product, bool isPrefered);
    }
}
