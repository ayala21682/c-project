using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class ProductImplementation:BlApi.IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(Product item)
        {
          return _dal.Product.Create(item.ConvertBOProductToDOProduct());
        }

        public void Delete(int itemId)
        {
            _dal.Product.Delete(itemId);
        }

        public Product? Read(int id)
        {
            return _dal.Product.Read(id).ConvertDOProductToBOProduct();
        }

        public Product? Read(Func<BO.Product, bool> filter)
        {
            return _dal.Product.ReadAll()
                .Select(c => c.ConvertDOProductToBOProduct())
                .FirstOrDefault(filter);
        }

        public List<Product?> ReadAll(Func<BO.Product, bool>? filter = null)
        {

            var list = _dal.Product.ReadAll().Select(p => p.ConvertDOProductToBOProduct());
            if (filter != null)
                list = list.Where(filter);
            return list.ToList()!;

        }

        public List<Product?> ReadAll()
        {
            var list = _dal.Product.ReadAll();
            return list.Select(c => c.ConvertDOProductToBOProduct()).ToList()!;


        }

        public void SalesOnProduct(ProductInOrder product, bool isPrefered)
        {          
            var list = from s in _dal.Sale.ReadAll()
                       where s.ProductId == product.ProductId
                       && (s.ForAllCustomers || isPrefered)
                       && s.BeginSale <= DateTime.Now
                       && s.EndSale >= DateTime.Now
                       && s.RequiredAmount <= product.AmountInOrder
                       select s;

            foreach (var item in list) {
                SaleInProduct saleInProduct = new SaleInProduct(item.SaleId, item.RequiredAmount, item.SalePrice, item.ForAllCustomers);
                product.ListOfSales.Add(saleInProduct);
            }
         
        }

        public void Update(Product item)
        {
           _dal.Product.Update(item.ConvertBOProductToDOProduct());
        }
    }
}
