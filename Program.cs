using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.DL;
using Departmental_Store_Management_System.UI;
namespace Departmental_Store_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MUserDL.loadUsers();
            ProductDL.loadProducts();
            CustomerDL.loadCustomer();

            while (true)
            {
                int option = MenuUI.menu();
                if (option == 1)
                {
                    int user = UserUI.signIN();
                    if (user != -1)
                    {
                        if (MUserDL.users[user].getRole() == "Admin")
                        {
                            Console.Clear();
                            while (true)
                            {
                                int op = MenuUI.adminMenu();
                                if (op == 1)
                                {
                                    //Add Product
                                    Product product = ProductUI.addProduct();
                                    ProductDL.addProductIntoList(product);
                                    ProductDL.storeProducts();
                                }
                                else if (op == 2)
                                {
                                    //view all products
                                    ProductUI.viewAllProducts();
                                }
                                else if (op == 3)
                                {
                                    //product with highest price
                                    Product product=ProductDL.highPriceProduct();
                                    ProductUI.displayProduct(product);
                                }
                                else if (op == 4)
                                {
                                    //sales tax
                                    Console.WriteLine("Tax : " + ProductDL.totalTax()) ;
                                }
                                else if (op == 5)
                                {
                                    //products with less quantity
                                    ProductUI.lowQuantityProducts();
                                }
                                else if (op == 6)
                                {
                                    ProductDL.storeProducts();
                                    break; 
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Option.");
                                }
                                MenuUI.clear();

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Customer customer =CustomerDL.checkCustomer(MUserDL.users[user]);
                            if (customer == null)
                            {
                                customer = new Customer();
                                customer.id = MUserDL.users[user];
                                CustomerDL.addToList(customer);
                            }
                            else
                            {
                                customer.id = MUserDL.users[user];
                            }
                            while (true)
                            {
                                int op = MenuUI.userMenu();
                                if (op == 1)
                                {
                                    //view all products
                                    ProductUI.viewAllProducts();
                                }
                                else if (op == 2)
                                {
                                    //buy products
                                    ProductUI.viewAllProducts();
                                    ProductUI.buyProduct(customer);
                                }
                                else if (op == 3)
                                {
                                    //Generate invoice
                                    CustomerUI.generateVoice(customer);
                                }
                                else if (op == 4)
                                {
                                    ProductDL.storeProducts();
                                    CustomerDL.storeCustomer();
                                    break;
                                }
                                else
                                {
                                    //invalid option
                                    Console.WriteLine("Invalid Option.");
                                }
                                MenuUI.clear();

                            }
                        }
                    }
                }
                else if (option == 2)
                {
                    UserUI.signUp();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option.");
                }
                MenuUI.clear();
            }
        }
    }
}
