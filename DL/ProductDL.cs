using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.DL;
using Departmental_Store_Management_System.UI;
namespace Departmental_Store_Management_System.DL
{
    internal class ProductDL
    {
        public static List<Product> products = new List<Product>();
        public static void addProductIntoList(Product p)
        {
            products.Add(p);
        }
        public static Product highPriceProduct()
        {
            List<Product> product = products.OrderByDescending(x => x.getPrice()).ToList();
            return product[0];
        }
        public static float totalTax()
        {
            float Tax = 0;
            foreach (Product p in products)
            {
                Tax = Tax + Product.calculateTax(p); 
            }
            return Tax;
        }
        public static Product isValidProduct(string name)
        {
            foreach (Product p in products)
            {
                if (name == p.getName())
                {
                    return p;
                }
            }
            return null;
        }
        public static void loadProducts()
        {
            string path = "Products.txt";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] products = line.Split(',');
                string name = products[0];
                string catagory = products[1];
                int price=int.Parse(products[2]);
                int availableQuantity=int.Parse(products[3]);
                int minQuantity=int.Parse(products[4]);
                Product product =   new Product(name, catagory, price, availableQuantity, minQuantity); 
                addProductIntoList(product);
            }
            sr.Close();
        }
        public static void storeProducts()
        {
            string path = "Products.txt";
            StreamWriter sw = new StreamWriter(path, false);
            foreach (Product p in products)
            {
                sw.WriteLine(p.getName()+","+p.getCatagory()+","+p.getPrice() + "," +p.getAvailableQuantity() + "," +p.getMinimumQuantity());
            }
            sw.Flush();
            sw.Close();
        }
    }
}
