using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal
{
    internal static class Config
    {
        static  string  filePath = "../xml/data-config.xml";



        public static int ProductId
        {
            get
            {
                XElement file = XElement.Load(filePath);
                XElement curProdID = file.Element("productId");
                int num = int.Parse(curProdID.Value);
                curProdID.SetValue(num + 1);
                file.Save(filePath);
                return num;
            }
        }
        public static int SaleId
        {
            get
            {
                XElement file = XElement.Load(filePath);
                XElement curSaleId = file.Element("saleId");
                int num = int.Parse(curSaleId.Value);
                curSaleId.SetValue(num + 1);
                file.Save(filePath);
                return num;
            }
        }
    }
}
