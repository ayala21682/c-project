////using BO;
////using DO;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using static BO.BlException;

////namespace BlImplementation
////{
////    internal class OrderImplementation:BlApi.IOrder
////    {
////        private DalApi.IDal _dal = DalApi.Factory.Get;
////        private ProductImplementation productImplementation = new ProductImplementation();
////        public List<SaleInProduct> AddProductToOrder(BO.Order order, int ProductId, int amount)
////        {

////            BO.Product product = _dal.Product.Read(ProductId).ConvertDOProductToBOProduct();
////            if (product != null)
////            {
////                if (product.Amount - amount > 0)
////                {
////                    product = product with { Amount = product.Amount - amount };                  

////                    ProductInOrder productInOrder = (from prod in order.ProductsOnOrder
////                                                     where prod.ProductId == ProductId
////                                                     select prod).FirstOrDefault()!;
////                    if (productInOrder != null)
////                    {
////                        if (productInOrder.AmountInOrder + amount > 0)
////                            productInOrder = productInOrder with
////                            {
////                                AmountInOrder = productInOrder.AmountInOrder + amount
////                            };
////                        else
////                            throw new BlNegetiveAmountInOrder("you cant order less then 1 product:)");
////                    }
////                    else
////                    {
////                        productInOrder = new ProductInOrder(product.ProductId, product.ProductName, product.Price, product.Amount, product.ListOfSales, 0);
////                        order.ProductsOnOrder.Add(productInOrder);
////                    } 

////                    SearchSaleForProduct(productInOrder,order.preferredCustomer);
////                    CalcTotalPriceForProduct(productInOrder);
////                    CalcTotalPrice(order);
////                    return productInOrder.ListOfSales;
////                }
////                else
////                    throw new BlNoProductInStock("There is not enough " + product.ProductName);
////            }
////            else
////            {              
////                    throw new BlIdNotExistsException("There is no Product " + product.ProductName);
////            }

////        }
////        public void CalcTotalPriceForProduct(ProductInOrder productInOrder)

////        {
////            int count = productInOrder.AmountInOrder;
////            double totalPrice = 0;
////            List<SaleInProduct> choosenSales = new();
////            foreach (var sale in productInOrder.ListOfSales)
////            {
////                if (count <= 0)
////                    break;
////                if (count < sale.AmountForSale)
////                   continue;

////                int timesOfSale = count / sale.AmountForSale;
////                totalPrice += timesOfSale * sale.Price;
////                count -= timesOfSale * sale.AmountForSale;
////                choosenSales.Add(sale);
////            }
////            totalPrice += count * productInOrder.BasicPrice;

////            productInOrder = productInOrder with
////            {
////                ListOfSales = choosenSales,
////                TotalPrice = totalPrice
////            };

////        }

////        public void CalcTotalPrice(Order order)
////        {
////           double totalPrice = 0;
////            foreach (var product in order.ProductsOnOrder)
////            {
////                CalcTotalPriceForProduct(product);
////                totalPrice += product.TotalPrice;
////            }
////        }


////        public void DoOrder(Order order)
////        {
////            foreach (var productInOrder in order.ProductsOnOrder)
////            { BO.Product p=_dal.Product.Read(productInOrder.ProductId).ConvertDOProductToBOProduct();
////                p = p with { Amount = p.Amount - productInOrder.AmountInOrder };
////                _dal.Product.Update(p.ConvertBOProductToDOProduct());
////            }
////        }

////        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isPrefered)
////        {
////            var list = _dal.Sale.ReadAll().Where(s => s.ProductId == productInOrder.ProductId)
////            .Where(s => s.ForAllCustomers || isPrefered)
////            .Where(s => s.BeginSale <= DateTime.Now)
////            .Where(s => s.EndSale >= DateTime.Now)
////            .Where(s => s.RequiredAmount <= productInOrder.AmountInOrder)
////            .OrderBy(s=>s.SalePrice/s.RequiredAmount)
////            .Select(s=>new SaleInProduct(s.SaleId,s.RequiredAmount,s.SalePrice,s.ForAllCustomers))
////            .ToList();

////            productInOrder = productInOrder with { ListOfSales = list };
////        }

////    }
////}
//using BO;
//using DO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static BO.BlException;

//namespace BlImplementation
//{
//    internal class OrderImplementation : BlApi.IOrder
//    {
//        private DalApi.IDal _dal = DalApi.Factory.Get;
//        private ProductImplementation productImplementation = new ProductImplementation();

//        public List<SaleInProduct> AddProductToOrder(BO.Order order, int ProductId, int amount)
//        {
//            BO.Product product = _dal.Product.Read(ProductId).ConvertDOProductToBOProduct();
//            if (product != null)
//            {
//                if (product.Amount - amount >= 0)
//                {
//                    product = product with { Amount = product.Amount - amount };

//                    ProductInOrder productInOrder = order.ProductsOnOrder.FirstOrDefault(prod => prod.ProductId == ProductId)!;

//                    if (productInOrder != null)
//                    {
//                        if (productInOrder.AmountInOrder + amount > 0)
//                        {
//                            productInOrder = productInOrder with
//                            {
//                                AmountInOrder = productInOrder.AmountInOrder + amount
//                            };
//                            int index = order.ProductsOnOrder.FindIndex(p => p.ProductId == ProductId);
//                            order.ProductsOnOrder[index] = productInOrder;
//                        }
//                        else
//                        {
//                            throw new BlNegetiveAmountInOrder("you cant order less then 1 product:)");
//                        }
//                    }
//                    else
//                    {
//                        productInOrder = new ProductInOrder(product.ProductId, product.ProductName, product.Price, amount, product.ListOfSales, 0);
//                        order.ProductsOnOrder.Add(productInOrder);
//                    }

//                    SearchSaleForProduct(productInOrder, order.preferredCustomer);

//                    int updatedIndex = order.ProductsOnOrder.FindIndex(p => p.ProductId == ProductId);
//                    productInOrder = order.ProductsOnOrder[updatedIndex];

//                    CalcTotalPriceForProduct(order,productInOrder);

//                    productInOrder = order.ProductsOnOrder[updatedIndex];

//                    CalcTotalPrice(order);

//                    return productInOrder.ListOfSales;
//                }
//                else
//                {
//                    throw new BlNoProductInStock("There is not enough " + product.ProductName);
//                }
//            }
//            else
//            {
//                throw new BlIdNotExistsException("There is no Product ID " + ProductId);
//            }
//        }

//        //public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
//        //{
//        //    int count = productInOrder.AmountInOrder;
//        //    double totalPrice = 0;
//        //    List<SaleInProduct> choosenSales = new();

//        //    foreach (var sale in productInOrder.ListOfSales)
//        //    {
//        //        if (count <= 0)
//        //            break;
//        //        if (count < sale.AmountForSale)
//        //            continue;

//        //        int timesOfSale = count / sale.AmountForSale;
//        //        totalPrice += timesOfSale * sale.Price;
//        //        count -= timesOfSale * sale.AmountForSale;
//        //        choosenSales.Add(sale);
//        //    }
//        //    totalPrice += count * productInOrder.BasicPrice;

//        //    productInOrder = productInOrder with
//        //    {
//        //        ListOfSales = choosenSales,
//        //        TotalPrice = totalPrice
//        //    };
//        //}
//        public void CalcTotalPriceForProduct(BO.Order order, ProductInOrder productInOrder)
//        {
//            int count = productInOrder.AmountInOrder;
//            double totalPrice = 0;
//            List<SaleInProduct> choosenSales = new();

//            foreach (var sale in productInOrder.ListOfSales)
//            {
//                if (count <= 0)
//                    break;
//                if (count < sale.AmountForSale)
//                    continue;

//                int timesOfSale = count / sale.AmountForSale;
//                totalPrice += timesOfSale * sale.Price;
//                count -= timesOfSale * sale.AmountForSale;
//                choosenSales.Add(sale);
//            }
//            totalPrice += count * productInOrder.BasicPrice;

//            var updatedProduct = productInOrder with
//            {
//                ListOfSales = choosenSales,
//                TotalPrice = totalPrice
//            };

//            int index = order.ProductsOnOrder.FindIndex(p => p.ProductId == productInOrder.ProductId);
//            if (index != -1)
//            {
//                order.ProductsOnOrder[index] = updatedProduct;
//            }
//        }
//        public void CalcTotalPrice(ref Order order)
//        {
//            double totalPrice = 0;
//            for (int i = 0; i < order.ProductsOnOrder.Count; i++)
//            {
//                CalcTotalPriceForProduct(order, order.ProductsOnOrder[i]);
//                totalPrice += order.ProductsOnOrder[i].TotalPrice;
//            }

//            order = order with { TotalPrice = totalPrice };
//        }
//        public void DoOrder(Order order)
//        {
//            foreach (var productInOrder in order.ProductsOnOrder)
//            {
//                BO.Product p = _dal.Product.Read(productInOrder.ProductId).ConvertDOProductToBOProduct();
//                p = p with { Amount = p.Amount - productInOrder.AmountInOrder };
//                _dal.Product.Update(p.ConvertBOProductToDOProduct());
//            }
//        }

//        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isPrefered)
//        {
//            var list = _dal.Sale.ReadAll()
//                .Where(s => s.ProductId == productInOrder.ProductId)
//                .Where(s => s.ForAllCustomers || isPrefered)
//                .Where(s => s.BeginSale <= DateTime.Now)
//                .Where(s => s.EndSale >= DateTime.Now)
//                .Where(s => s.RequiredAmount <= productInOrder.AmountInOrder)
//                .OrderBy(s => s.SalePrice / s.RequiredAmount)
//                .Select(s => new SaleInProduct(s.SaleId, s.RequiredAmount, s.SalePrice, s.ForAllCustomers))
//                .ToList();

//            productInOrder = productInOrder with { ListOfSales = list };
//        }


//    }
//}
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.BlException;

namespace BlImplementation
{
    internal class OrderImplementation : BlApi.IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
        private ProductImplementation productImplementation = new ProductImplementation();

        public List<SaleInProduct> AddProductToOrder(BO.Order order, int ProductId, int amount)
        {
            BO.Product product = _dal.Product.Read(ProductId).ConvertDOProductToBOProduct();
            if (product != null)
            {
                if (product.Amount - amount >= 0)
                {
                    product = product with { Amount = product.Amount - amount };

                    ProductInOrder productInOrder = order.ProductsOnOrder.FirstOrDefault(prod => prod.ProductId == ProductId)!;

                    if (productInOrder != null)
                    {
                        if (productInOrder.AmountInOrder + amount > 0)
                        {
                            productInOrder = productInOrder with
                            {
                                AmountInOrder = productInOrder.AmountInOrder + amount
                            };
                            int index = order.ProductsOnOrder.FindIndex(p => p.ProductId == ProductId);
                            order.ProductsOnOrder[index] = productInOrder;
                        }
                        else
                        {
                            throw new BlNegetiveAmountInOrder("you cant order less then 1 product:)");
                        }
                    }
                    else
                    {
                        productInOrder = new ProductInOrder(product.ProductId, product.ProductName, product.Price, amount, product.ListOfSales, 0);
                        order.ProductsOnOrder.Add(productInOrder);
                    }

                    SearchSaleForProduct(order, productInOrder, order.preferredCustomer);

                    int updatedIndex = order.ProductsOnOrder.FindIndex(p => p.ProductId == ProductId);
                    productInOrder = order.ProductsOnOrder[updatedIndex];

                    CalcTotalPriceForProduct(order, productInOrder);

                    productInOrder = order.ProductsOnOrder[updatedIndex];

                    CalcTotalPrice(ref order);

                    productInOrder = order.ProductsOnOrder[updatedIndex];

                    return productInOrder.ListOfSales;
                }
                else
                {
                    throw new BlNoProductInStock("There is not enough " + product.ProductName);
                }
            }
            else
            {
                throw new BlIdNotExistsException("There is no Product ID " + ProductId);
            }
        }

        public void CalcTotalPriceForProduct(BO.Order order, ProductInOrder productInOrder)
        {
            int count = productInOrder.AmountInOrder;
            double totalPrice = 0;
            List<SaleInProduct> choosenSales = new();

            foreach (var sale in productInOrder.ListOfSales)
            {
                if (count <= 0)
                    break;
                if (count < sale.AmountForSale)
                    continue;

                int timesOfSale = count / sale.AmountForSale;
                totalPrice += timesOfSale * sale.Price;
                count -= timesOfSale * sale.AmountForSale;
                choosenSales.Add(sale);
            }
            totalPrice += count * productInOrder.BasicPrice;

            var updatedProduct = productInOrder with
            {
                ListOfSales = choosenSales,
                TotalPrice = totalPrice
            };

            int index = order.ProductsOnOrder.FindIndex(p => p.ProductId == productInOrder.ProductId);
            if (index != -1)
            {
                order.ProductsOnOrder[index] = updatedProduct;
            }
        }

        public void CalcTotalPrice(ref Order order)
        {
            double totalPrice = 0;
            for (int i = 0; i < order.ProductsOnOrder.Count; i++)
            {
                CalcTotalPriceForProduct(order, order.ProductsOnOrder[i]);
                totalPrice += order.ProductsOnOrder[i].TotalPrice;
            }

            order = order with { TotalPrice = totalPrice };
        }

        public void DoOrder(Order order)
        {
            foreach (var productInOrder in order.ProductsOnOrder)
            {
                BO.Product p = _dal.Product.Read(productInOrder.ProductId).ConvertDOProductToBOProduct();
                p = p with { Amount = p.Amount - productInOrder.AmountInOrder };
                _dal.Product.Update(p.ConvertBOProductToDOProduct());
            }
        }

        public void SearchSaleForProduct(BO.Order order, ProductInOrder productInOrder, bool isPrefered)
        {
            var list = _dal.Sale.ReadAll()
                .Where(s => s.ProductId == productInOrder.ProductId)
                .Where(s => s.ForAllCustomers || isPrefered)
                .Where(s => s.BeginSale <= DateTime.Now)
                .Where(s => s.EndSale >= DateTime.Now)
                .Where(s => s.RequiredAmount <= productInOrder.AmountInOrder)
                .OrderBy(s => s.SalePrice / s.RequiredAmount)
                .Select(s => new SaleInProduct(s.SaleId, s.RequiredAmount, s.SalePrice, s.ForAllCustomers))
                .ToList();

            var updatedProduct = productInOrder with { ListOfSales = list };

            int index = order.ProductsOnOrder.FindIndex(p => p.ProductId == productInOrder.ProductId);
            if (index != -1)
            {
                order.ProductsOnOrder[index] = updatedProduct;
            }
        }
    }
}