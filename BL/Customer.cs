using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departmental_Store_Management_System.BL
{
    internal class Customer
    {
        public MUser id ;
        public List<Product> products =new List<Product>();
        public Customer() { }
        public Customer(MUser id,List<Product> p)
        {
            this.id = id;
            this.products = p;
        }
        public float price()
        {
            float price = 0;
            foreach(Product p in products)
            {
                price=price+ Product.calculateTax(p);
            }
            return price;

        }
        public void addToList(Product p)
        {
            products.Add(p);
        }
    }
}
