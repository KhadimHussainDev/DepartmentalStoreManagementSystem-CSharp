using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.DL;
namespace Departmental_Store_Management_System.UI
{
    internal class ProductUI
    {
        public static void viewAllProducts()
        {
            Console.WriteLine("Name\tPrice\tStock\tCatagory");
            foreach (Product p in ProductDL.products)
            {
                displayProduct(p);
            }
        }
        public static void buyProduct(Customer customer)
        {
            Console.WriteLine("Enter Name of Product : ");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            Product product = ProductDL.isValidProduct(productName);
            if (product == null)
            {
                Console.WriteLine("No Product Found With This Name.");
            }
            else
            {
                if (product.getAvailableQuantity() >= quantity)
                {
                    int stock=product.getAvailableQuantity()- quantity;
                    product.setAvailableQuantity(stock);
                    customer.addToList(product);
                    CustomerDL.storeCustomer();

                }
                else
                {
                    Console.WriteLine("Limited Stock.");
                }
            }
        }
        public static void displayProduct(Product p)
        {
            Console.WriteLine(p.getName() + "\t" + p.getPrice() + "\t" + p.getAvailableQuantity() + "\t" + p.getCatagory());
        }
        public static Product addProduct()
        {
            Console.Write("Enter Name of Product : ");
            string name = Console.ReadLine();
            Console.Write("Enter Catagory of Product : ");
            string catagory = Console.ReadLine();
            Console.Write("Enter Price of Product : ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter Available Quantity of Product : ");
            int availableQuantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Threshold Quqntity of Product : ");
            int minimumQuantity = int.Parse(Console.ReadLine());
            Product product = new Product(name, catagory, price, availableQuantity, minimumQuantity);
            return product;
        }
        public static void lowQuantityProducts()
        {
            Console.WriteLine("Name\tPrice\tStock\tCatagory");
            foreach (Product p in ProductDL.products)
            {
                if (p.getMinimumQuantity() >= p.getAvailableQuantity())
                {
                    displayProduct(p);
                }
            }
        }
    }
}
