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
        List<User> userList = new List<User>(){
                    new User() { UserId = 1, Username = "Jejeje", Password = "Password123", FirstName = "Je-an", LastName = "Onting" },
                    new User() { UserId = 2, Username = "Myeli", Password = "Password123", FirstName = "Mel", LastName = "Meji" }
        };


        public List<User> GetUserList()
        {
            return userList;
        }

        public void AddToList(User user)
        {
            User usernew = new User() { UserId = 1003, Username = "Myeli", Password = "Password123", FirstName = "Mel", LastName = "Meji" };

            userList.Add(usernew);
        }

        public void RemoveToList(User user)
        {
            userList.RemoveAll(u => u.UserId == user.UserId);
        }

        public void UpdateList(User user)
        {
            foreach (var ud_user in userList.Where(u => u.UserId == user.UserId))
            {
                ud_user.UserId = user.UserId;
                ud_user.Username = user.Username;
                ud_user.FirstName = user.FirstName;
                ud_user.LastName = user.LastName;
                ud_user.Password = user.Password;
            }
        }
    }
}
