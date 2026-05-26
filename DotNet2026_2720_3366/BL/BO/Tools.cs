//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace BO
//{
//  static internal class Tools
//    {
//        public static String ToStringProperty()
//        {
//            return "";
//        }
       
//    }

//}

using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T t,string prefix="")
        {
           StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo item in t.GetType().GetProperties())
            {
                if (item.PropertyType.IsPrimitive ||
                    item.PropertyType == typeof(DateTime) ||
                    item.PropertyType == typeof(string))
                    sb.AppendLine($"{prefix}{item.Name}:{item.GetValue(t)}");
                else
                {
                    sb.AppendLine($"{prefix}{item.Name}");
                    sb.AppendLine(item.GetValue(t).ToStringProperty(prefix + "\t"));
                }
            }
            return sb.ToString();
           
        }
        
        public static BO.Customer ConvertDOCustomerToBOCustomer(this DO.Customer customer)
        {
            if(customer == null)
                return null;
            return new BO.Customer(customer.CustomerId, customer.CustomerName, customer.Address, customer.PhoneNumber);

        }
        public static BO.Product ConvertDOProductToBOProduct(this DO.Product product)
        {
            if(product == null)
                return null;
            return new BO.Product(
                product.ProductId,
                product.ProductName,
                (BO.Category)product.ProductCategorey, // הוספת ההמרה המפורשת כאן
                product.Price,
                product.Amount,
                new List<BO.SaleInProduct>()
            );
        }
        public static BO.Sale ConvertDOSaleToBOSale(this DO.Sale sale)
        {
            if(sale == null)
                return null;
            return new BO.Sale(sale.SaleId,sale.ProductId,sale.RequiredAmount,sale.SalePrice,sale.ForAllCustomers,sale.BeginSale,sale.EndSale);
        }
        public static DO.Customer ConvertBOCustomerToDOCustomer(this BO.Customer customer)
        {if(customer == null)
                return null;
            return new DO.Customer(customer.CustomerId, customer.CustomerName, customer.Address, customer.PhoneNumber);
        }
        public static DO.Product ConvertBOProductToDOProduct(this BO.Product product)
        {if (product == null)
                return null;
            return new DO.Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                // המרה מפורשת מ-BO.Category ל-DO.Category
                ProductCategorey = (DO.Category)product.ProductCategorey,
                Price = product.Price,
                Amount = product.Amount
            };
        }
        public static DO.Sale ConvertBOSaleToDOSale(this BO.Sale sale)
        {if(sale == null)
                return null;
            return new DO.Sale(sale.SaleId, sale.ProductId, sale.RequiredAmount, sale.SalePrice, sale.ForAllCustomers, sale.BeginSale, sale.EndSale);
        }


    }
}

