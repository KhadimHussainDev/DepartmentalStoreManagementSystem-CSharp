using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.DL;
namespace Departmental_Store_Management_System.UI
{
    internal class UserUI
    {
        public static int signIN()
        {
            Console.WriteLine("Enter Username :");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password :");
            string password = Console.ReadLine();
            int found = MUserDL.signIn(username, password);
            if (found == -1)
            {
                Console.WriteLine("Invalid Username  or Password.");
            }
            else
            {
                Console.WriteLine("Login Succesful.");
            }

            return found;
        }
        public static void signUp()
        {
            Console.WriteLine("Enter Username :");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password :");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role :");
            string role = Console.ReadLine();
            MUserDL.signUp(username, password, role);
            Console.WriteLine("Account Created Successfully.");

        }

    }
}
