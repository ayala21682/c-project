using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        const string SALEID = "SaleId";
        const string PRODUCTID = "ProductId";
        const string REQUIREDAMOUNT = "RequiredAmount";
        const string SALEPRICE = "SalePrice";
        const string FORALLCUSTOMER = "ForAllCustomers";
        const string BEGINSALE = "BeginSale";
        const string ENDSALE = "EndSale";

        const string filePath = "../xml/sales.xml";
        public int Create(Sale sa)
        {
            XElement root = XElement.Load(filePath);
            XElement saleElement = new XElement("Sale",
                new XElement(SALEID, Config.SaleId),
                new XElement(PRODUCTID, sa.ProductId),
                new XElement(REQUIREDAMOUNT, sa.RequiredAmount),
                new XElement(SALEPRICE, sa.SalePrice),
                new XElement(FORALLCUSTOMER, sa.ForAllCustomers),
                new XElement(BEGINSALE, sa.BeginSale),
                new XElement(ENDSALE, sa.EndSale)
            );
            root.Add(saleElement);
            root.Save(filePath);
            return sa.SaleId;
        }

        public void Delete(int saId)
        {
            XElement xElement = XElement.Load(filePath);
        
            XElement saleElement = xElement.Descendants(SALEID)
                               .FirstOrDefault(e => int.Parse(e.Value) == saId);

            if (saleElement != null && saleElement.Parent != null)
            {
                saleElement.Parent.Remove();
                xElement.Save(filePath);
            }
            else
            {
                Console.WriteLine("Sale with this ID not found.");
            }
            xElement.Save(filePath);
        }

        public Sale? Read(int saId)
        {
            XElement xElement = XElement.Load(filePath);
            XElement xSale = xElement.Descendants(SALEID).FirstOrDefault(s => int.Parse(s.Value) == saId).Parent;
            if (xSale != null)
            {
                return new Sale
                {
                    SaleId = int.Parse(xSale.Element(SALEID).Value),
                    ProductId = int.Parse(xSale.Element(PRODUCTID).Value),
                    RequiredAmount = int.Parse(xSale.Element(REQUIREDAMOUNT).Value),
                    SalePrice = double.Parse(xSale.Element(SALEPRICE).Value),
                    ForAllCustomers = bool.Parse(xSale.Element(FORALLCUSTOMER).Value),
                    BeginSale = DateTime.Parse(xSale.Element(BEGINSALE).Value),
                    EndSale = DateTime.Parse(xSale.Element(ENDSALE).Value)
                };
            }
            else
            {
                return null;
            }
        }
        public Sale? Read(Func<Sale, bool> filter)
        {
            List<Sale> sales = ReadAll();
            Sale? sale = sales.FirstOrDefault(s=>filter(s));
            if(sale != null)
                return sale;
            return null ;
        }

        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            List<Sale> sales = ReadAll();
            if (filter != null)
                return sales.Where(filter).ToList();
            return sales;


        }

        public List<Sale?> ReadAll()
        {
            XElement xElement = XElement.Load(filePath);
            List<Sale> xSale = xElement.Elements().Select(s => new Sale
            {
                SaleId = int.Parse(s.Element(SALEID).Value),
                ProductId = int.Parse(s.Element(PRODUCTID).Value),
                RequiredAmount = int.Parse(s.Element(REQUIREDAMOUNT).Value),
                SalePrice = double.Parse(s.Element(SALEPRICE).Value),
                ForAllCustomers = bool.Parse(s.Element(FORALLCUSTOMER).Value),
                BeginSale = DateTime.Parse(s.Element(BEGINSALE).Value),
                EndSale = DateTime.Parse(s.Element(ENDSALE).Value)
            }).ToList();
            if (xSale != null)
                return xSale;
            return null;
        }

        public void Update(Sale sa)
        {
            XElement root = XElement.Load("xml/sales.xml");
            XElement saleElement = root.Elements("Sale")
                .FirstOrDefault(e => (int)e.Element("SaleId") == sa.SaleId);
            if (saleElement != null)
            {
                saleElement.Element("ProductId").Value = sa.ProductId.ToString();
                saleElement.Element("RequiredAmount").Value = sa.RequiredAmount.ToString();
                saleElement.Element("SalePrice").Value = sa.SalePrice.ToString();
                saleElement.Element("ForAllCustomers").Value = sa.ForAllCustomers.ToString();
                saleElement.Element("BeginSale").Value = sa.BeginSale.ToString("o");
                saleElement.Element("EndSale").Value = sa.EndSale.ToString("o");

            }
            root.Save("xml/sales.xml");
        }
    }
}

