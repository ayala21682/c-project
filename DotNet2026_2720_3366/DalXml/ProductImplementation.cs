using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal
{
    internal class ProductImplementation:IProduct
    {
        string filePath = "../xml/products.xml";
        public int Create(Product pro)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    products = serializer.Deserialize(reader) as List<Product>;
                }
            }
            else
            {
                products = new List<Product>();
            }
            Product pro2=pro with { ProductId = Config.ProductId};
            products.Add(pro2);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, products);
            }

            return pro2.ProductId;
        }

        public Product? Read(int id)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;


            if (!File.Exists(filePath))
                return null;

            using (StreamReader reader = new StreamReader(filePath))
            {
                products = serializer.Deserialize(reader) as List<Product>;
            }

            return products.FirstOrDefault(p => p.ProductId == id);
        }

        public Product? Read(Func<Product, bool> filter)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;


            using (StreamReader reader = new StreamReader(filePath))
            {
                products = serializer.Deserialize(reader) as List<Product>;
            }

            return products.FirstOrDefault(p => filter(p) == true);
        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;


            if (!File.Exists(filePath))
                return null;

            using (StreamReader reader = new StreamReader(filePath))
            {
                products = serializer.Deserialize(reader) as List<Product>;
            }
            if (filter != null)
                products = products.Where(filter).ToList();
            return products;



        }
        public List<Product?> ReadAll()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;


            if (!File.Exists(filePath))
                return null;

            using (StreamReader reader = new StreamReader(filePath))
            {
                products = serializer.Deserialize(reader) as List<Product>;
            }

            return products;

        }

        public void Delete(int proId)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    products = serializer.Deserialize(reader) as List<Product>;
                }
            }
            else
            {
                products = new List<Product>();
            }
            Product pro = products.FirstOrDefault(p => p.ProductId == proId);
            products.Remove(pro);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, products);
            }


        }

        public void Update(Product pro)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            List<Product> products;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    products = serializer.Deserialize(reader) as List<Product>;
                }
            }
            else
            {
                products = new List<Product>();
            }
            Product newcustomer = products.FirstOrDefault(p => p.ProductId == pro.ProductId);
            products.Remove(newcustomer);

            products.Add(pro);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, products);
            }
        }
    }

}
