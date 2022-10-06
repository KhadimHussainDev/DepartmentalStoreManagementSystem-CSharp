using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departmental_Store_Management_System.BL
{
    internal class MUser
    {
        private string userName;
        private string password;
        private string role;
        public MUser(string userName,string password,string role)
        {
            this.userName = userName;
            this.password = password;
            this.role = role;
        }
        public string getUserName() {  return userName;  }
        public string getPassword() { return password; }
        public string getRole() { return role; }
        public void setUserName(string userName) { this.userName = userName; }
        public void setPassword(string password) { this.password = password; }
        public void setRole(string role) { this.role = role; }
       
    }
}
