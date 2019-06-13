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
        Regex regexPassword = new Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{5,25})$");

        public void CreateNewUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new ArgumentException("You passed in an invalid parameter", "Username");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("You passed in an invalid parameter", "Password");
            }


            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "LastName");
            }

           //userList.Add(user);
           userRepo.AddToList(user);

        }

        public List<User> RetrieveUserList()
        {
            //return userList;
            return userRepo.GetUserList();
        }

        public User RetrieveUser(User user)
        {
            User user_exist = userRepo.GetUserList().Find(u => u.UserId == user.UserId);
            return user_exist;
        }
        public void UpdateUser(User user)
        {
            //User user_exist = userRepo.GetUserList().FirstOrDefault(u => u.UserId == user.UserId);
            if (IsUserExist(user))
            {
                userRepo.UpdateList(user);
            }


        }
        public void DeleteUser(User user)
        {
            
            if (IsUserExist(user))
            {
                //userList.RemoveAll(u => u.UserId == user.UserId);
                userRepo.RemoveToList(user);
            }

        }

        public bool IsUserExist(User user)
        {
            User user_exist = userRepo.GetUserList().FirstOrDefault(u => u.UserId == user.UserId);
            //User user_exist = GetUserList().Find(u => u.UserId == user.UserId);

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
            if (regexPassword.IsMatch(password) && password.Length > 5)
            {
                return true;
            }

            return false;
        }
    }
}
