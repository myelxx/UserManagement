using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepo
    {
        List<User> userList = new List<User>();
       

        public List<User> GetUserList()
        {
            if (userList != null)
            {
                userList = new List<User>() {
                    new User() { UserId = 1, Username = "Jejeje", Password = "Password123", FirstName = "Je-an", LastName = "Onting" },
                    new User() { UserId = 2, Username = "Myeli", Password = "Password123", FirstName = "Mel", LastName = "Meji" }
                };
            }

            //foreach(var item in userList)
            //{
            //    Console.WriteLine("hshshs");
            //}
            return userList;
        }

        public void AddToList(User user)
        {
            userList.Add(user);
        }

        public void RemoveToList(User user)
        {
            userList.Remove(user);
        }

        public void UpdateList(User user)
        {
            foreach (var item in GetUserList().Where(w => w.UserId == user.UserId))
            {
                item.Username = user.Username;
                item.Password = user.Password;
                item.FirstName = user.FirstName;
                item.LastName = user.LastName;
            }
        }
    }
}
