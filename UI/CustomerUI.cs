using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;
using Departmental_Store_Management_System.DL;
namespace Departmental_Store_Management_System.UI
{
    internal class CustomerUI
    {
        public static void generateVoice(Customer customer)
        {
            Console.WriteLine("Total Price : "+ customer.price());
        }
    }
}
