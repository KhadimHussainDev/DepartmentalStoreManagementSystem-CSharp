using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departmental_Store_Management_System.BL
{
    internal class Product
    {
        private string name;
        private string catagory;
        private int price;
        private int availableQuantity;
        private int minimumQuantity;
        public string getName() { return name; }
        public string getCatagory() { return catagory; }
        public int getPrice() { return price; }
        public int getAvailableQuantity() { return availableQuantity; }
        public int getMinimumQuantity() { return minimumQuantity; }
        public void setName(string name) { this.name = name; }
        public void seCatagory(string catagory) { this.catagory = catagory; }
        public void setPrice(int price) { this.price = price; }
        public void setAvailableQuantity(int availableQuantity) { this.availableQuantity = availableQuantity; }
        public void setMinimumQuantity(int minimumQuantity) { this.minimumQuantity = minimumQuantity; }
        public Product(string name, string catagory, int price, int availableQuantity, int minimumQuantity)
        {
            this.name = name;
            this.catagory = catagory;
            this.price = price;
            this.availableQuantity = availableQuantity;
            this.minimumQuantity = minimumQuantity;
        }
        public static float calculateTax(Product p)
        {
            float tax , Tax=0;
            if (p == null) { }
            else
            {
                if (p.catagory == "Grocery")
                {
                    tax = 10;
                }
                else if (p.catagory == "Fruit")
                {
                    tax = 5;
                }
                else
                {
                    tax = 15;
                }
                Tax = p.price + p.price * tax / 100;
            }
            return Tax;
        }
    }
}
