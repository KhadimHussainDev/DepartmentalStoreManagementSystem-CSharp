using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.UI;
namespace Departmental_Store_Management_System.DL
{
    internal class CustomerDL
    {
        public static List<Customer> customers = new List<Customer>();
        public static void addToList(Customer customer)
        {
            customers.Add(customer);
        }
        public static Customer checkCustomer(MUser user)
        {
            foreach (Customer customer in customers)
            {
                if (customer.id.getUserName() == user.getUserName() && customer.id.getPassword() == user.getPassword() && customer.id.getRole() == user.getRole())
                {
                    return customer;
                }
            }
            return null;
        }
        public static void loadCustomer()
        {
            string path = "Customer.txt";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                List<Product> products = new List<Product>();
                string line = sr.ReadLine();
                string[] cust = line.Split(',');
                string name = cust[0];
                string pass = cust[1];
                string role = cust[2];
                string prod = cust[3];
                MUser id = new MUser(name, pass, role);
                string[] p = prod.Split(';');
                for (int i = 0; i < p.Length; i++)
                {
                    string product1 = p[i];
                    Product p1 = ProductDL.isValidProduct(product1);
                    if(p1!= null)
                    {
                    products.Add(p1);

                    }
                }

                Customer customer = new Customer(id, products);
                addToList(customer);
            }
            sr.Close();
        }
        public static void storeCustomer()
        {
            string path = "Customer.txt";
            StreamWriter sw = new StreamWriter(path, false);
            foreach (Customer c in customers)
            {
                sw.Write(c.id.getUserName() + "," + c.id.getPassword() + "," + c.id.getRole() + ",");
                foreach (Product p in c.products)
                {
                    sw.Write(p.getName() + ";");
                }
                sw.WriteLine();
            }
            sw.Flush();
            sw.Close();
        }
    }
}
