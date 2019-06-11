using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Business
{
    public class UserControl
    {
        UserRepo userRepo = new UserRepo();
        Regex regexPassword = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");

        public bool CreateNewUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                return false;
            }

            userRepo.AddToList(user);
            return true;
        }

        public List<User> RetrieveUser()
        {
            return userRepo.GetUserList();
        }
        public bool UpdateUser(User user)
        {
            User user_exist = userRepo.GetUserList().FirstOrDefault(u => u.UserId == user.UserId);

            if (user_exist == null)
            {
                return false;
            }

            userRepo.UpdateList(user);
            return true;
        }
        public bool DeleteUser(User user)
        {
            User user_exist = userRepo.GetUserList().FirstOrDefault(u => u.UserId == user.UserId);

            if (user_exist == null)
            {
                return false;

            }

            userRepo.RemoveToList(user);
            return true;
        }

        public bool IsUserExist(User user)
        {
            User user_exist = userRepo.GetUserList().FirstOrDefault(u => u.UserId == user.UserId);

            if (user_exist == null)
            {
                return false;

            }
            return true;
        }

        public bool IsUsernameValid(string username)
        {
            if(username.Length < 5)
            {
                return false;
            }
            return true;
        }

        public bool IsPasswordValid(string password)
        {
            if (regexPassword.IsMatch(password))
            {
                return false;
            }

            if (password.Length < 5 )
            {
                return false;
            }

            return true;
        }
    }
}
