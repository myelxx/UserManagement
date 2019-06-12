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
            User user = new User() { UserId = 6, Username = "YOWWwwww", Password = "Pasword1234", FirstName = "gsgsgsgs", LastName = "gsgsgsgsgs" };
            List<User> userlist = usercontrol.RetrieveUserList();
            foreach(var i in userlist)
            {
                Console.WriteLine(i.UserId);
            }
            usercontrol.CreateNewUser(user);
            foreach (var i in userlist)
            {
                Console.WriteLine(i.UserId);
            }
        }
    }
}
