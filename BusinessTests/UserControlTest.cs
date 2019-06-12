using Business;
using Domain;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessTests
{
    public class UserControlTest
    {
        List<User> userList;
        UserControl userControl = new UserControl();
        UserRepo userRepo = new UserRepo();

        //public static IEnumerable<object[]> ValidUserData => new List<object[]>
        //{
        //       new object[] {1, "Myoolz", "Password123", "Steve", "Carey"},
        //};

        [Theory]
        [InlineData("Alpha", true)] //valid
        [InlineData("o", false)] //invalid
        public void CheckIfUsernameIsValid(string userName, bool isValid)
        {
            bool expected = userControl.IsUsernameValid(userName);
            bool actual = isValid;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Password123", true)]
        [InlineData("password", false)]
        public void CheckIfPasswordIsValid(string password, bool isValid)
        {
            bool actual = userControl.IsPasswordValid(password);
            bool expected = isValid;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, true)] //valid
        [InlineData(4, false)] //invalid
        public void CheckIsUserExist(int userId, bool isUserExist)
        {
            User newUser = new User() { UserId = userId };
            bool actual = userControl.IsUserExist(newUser); 
            bool expected = isUserExist; 

            Assert.Equal(expected, actual);
        }

        
        [Theory]
        [InlineData(3, "Myelxx", "Password123", "Mel", "Meji")]
        public void CreateNewUser_ShouldWork(int userId, string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            userControl.CreateNewUser(newUser); //create
            var actual = userControl.RetrieveUserList(); //retrieve

            Assert.Contains(newUser, actual); //compare
            //Assert.Contains<User>(newUser, actual);
        }

        [Theory]
        [InlineData("Myelxx", "Password123", "", "Meji", "FirstName")]
        [InlineData("Myelxx", "Password123", "Mel", "", "LastName")]
        [InlineData("", "Password123", "Mel", "Meji", "Username")]
        [InlineData("Myelxx", "", "Mel", "Meji", "Password")]

        public void CreateNewUser_ShouldFail(string userName, string password, string firstName, string lastName, string param)
        {
            User newUser = new User { Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            //Assert.False(userControl.CreateNewUser(newUser));
            Assert.Throws<ArgumentException>(param, () => userControl.CreateNewUser(newUser));
        }

        [Fact]
        public void RetrieveUser_ShouldReturnList()
        {
            userList = userControl.RetrieveUserList();
            Assert.NotEmpty(userRepo.GetUserList());
        }

        [Theory]
        [InlineData(1, "XXXXXXX", "MMMMMMMM", "MMMMMMMM", "MMMMMMMMM")]
        public void UpdateUser_ShouldWork(int userId, string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            userControl.UpdateUser(newUser); 

            var actual = userControl.RetrieveUserList(); 
            User user_exist = actual.Find(u => u.UserId == userId);

            Assert.Equal(newUser.UserId, user_exist.UserId);
            Assert.Equal(newUser.FirstName, user_exist.FirstName);
            Assert.Equal(newUser.LastName, user_exist.LastName);
            Assert.Equal(newUser.Username, user_exist.Username);
            Assert.Equal(newUser.Password, user_exist.Password);
            //Assert.Contains(newUser, actual);
        }

        [Theory]
        [InlineData(5, "Myelxx", "Password101", "Mel", "Meji", "UserId")]
        public void UpdateUser_ShouldFail(int userId, string userName, string password, string firstName, string lastName, string param)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };

            //check if user exist
            User actual = userControl.RetrieveUser(newUser); 
            Assert.Null(actual);
        }

        [Theory]
        [InlineData(1)]

        public void DeleteUser_ShouldWork(int userId)
        {
            User newUser = new User { UserId = userId };
            userControl.DeleteUser(newUser);
            var actual = userControl.RetrieveUserList(); //retrieve list

            Assert.DoesNotContain(newUser, actual);
        }

        [Theory]
        [InlineData(3)] 

        public void DeleteUser_ShouldFail(int userId)
        {
            User newUser = new User { UserId = userId };

            //check if user exist
            User actual = userControl.RetrieveUser(newUser);
            Assert.Null(actual);
        }

    }
}
