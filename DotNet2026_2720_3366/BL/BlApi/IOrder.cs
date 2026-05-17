using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IOrder
    {
        public List<SaleInProduct> AddProductToOrder(Order order,int ProductId,int Amount);
        public void CalcTotalPriceForProduct(Order order,ProductInOrder productInOrder);
        public void CalcTotalPrice(Order order);
        public void DoOrder(Order order);
        public void SearchSaleForProduct(ProductInOrder productInOrder,bool isPrefered);
    }
}
