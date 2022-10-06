using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Departmental_Store_Management_System.BL;

namespace Departmental_Store_Management_System.DL
{
    internal class MUserDL
    {
        public static List<MUser> users = new List<MUser>();
        public static void loadUsers()
        {
            string path = "passwords.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string user = parseData(line, 1);
                    string pass = parseData(line, 2);
                    string role = parseData(line, 3);
                    MUser mUser = new MUser(user, pass, role);
                    users.Add(mUser);
                }
                sr.Close();

            }
            else
            {
                Console.WriteLine("File Not found.");
            }

        }
        public static void signUp(string username, string password,string role)
        {
            string path = "passwords.txt";
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(username + "," + password+","+role);
            sw.Flush();
            sw.Close();
            MUser mUser = new MUser(username, password, role);
            users.Add(mUser);
        }

        public static string parseData(string line, int field)
        {
            string req = "";
            int count = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    count++;
                }
                else if (field == count)
                {
                    req = req + line[i];
                }
            }
            return req;
        }
        public static int signIn(string username, string password)
        {
            int idx = 0;
            foreach(MUser mUser in users)
            {
                if (username == mUser.getUserName() && password == mUser.getPassword())
                {
                    return idx;
                }
                idx++;
            }
            return -1;
        }
    }
}
