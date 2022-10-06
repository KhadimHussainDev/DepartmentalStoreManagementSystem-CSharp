using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.DL;

namespace Departmental_Store_Management_System.UI
{
    internal class MenuUI
    {
        public static int menu()
        {
            Console.WriteLine("Choose One Option : ");
            Console.WriteLine("1.Sign In  ");
            Console.WriteLine("2.Sign Up  ");
            Console.WriteLine("3.Exit  ");
            Console.Write("Your Option : ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static void clear()
        {
            Console.WriteLine("Press any Key To Continue...");
            Console.ReadKey();
            Console.Clear();
        }
    
        public static int adminMenu()
        {
            Console.WriteLine("1.Add Product\n2.View All Products\n3.Find Product with Highest Unit Price\n4.View Sales Tax of All Products\n5.Products to be Ordered\n6.Exit");
            Console.WriteLine("Your Option...");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static int userMenu()
        {
            Console.WriteLine("1.View all the products\n2.Buy the products\n3.Generate invoice\n4.Exit");
            Console.WriteLine("Your Option...");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

    }
}
