using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
    public record ProductInOrder(int ProductId, string ProductName, double BasicPrice, int AmountInOrder, List<SaleInProduct> ListOfSales,double TotalPrice=0)
    {
        public ProductInOrder() : this(0, "", 0.0, 0, new List<SaleInProduct>(),0.0)
        {

        }
        public override string ToString()
        {
            string salesStr = ListOfSales != null && ListOfSales.Any()
                ? string.Join(", ", ListOfSales.Select(s => s.ToString()))
                : "None";

            return $"ProductInOrder {{ ProductId = {ProductId}, ProductName = {ProductName}, BasicPrice = {BasicPrice}, AmountInOrder = {AmountInOrder}, TotalPrice = {TotalPrice}, ListOfSales = [{salesStr}] }}";
        }
    }
}
