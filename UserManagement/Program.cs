using Business;
using Domain;
using Repository;
using System;
using System.Collections.Generic;

namespace UserManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserControl usercontrol = new UserControl();
            User user = new User() { UserId = 1, Username = "YOWW" };
            List<User> userlist = usercontrol.GetUserList();
            foreach(var i in userlist)
            {
                Console.WriteLine(i.UserId);
            }
            usercontrol.DeleteUser(user);
            foreach (var i in userlist)
            {
                Console.WriteLine(i.Username);
            }
        }
    }
}
