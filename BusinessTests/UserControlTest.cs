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
        public static IEnumerable<object[]> InvalidUserData => new List<object[]>
        {
               new object[] { "", "Password123", "Steve", "Carey" },
               new object[] { "Myeling", "", "Mel", "Meji"},
               new object[] { "Myelxx", "Password123", "", "Meji"},
               new object[] { "Myelxx", "Password123", "Mel", ""}
        };

        public static IEnumerable<object[]> ValidUserData => new List<object[]>
        {
               new object[] {1, "Myoolz", "Password123", "Steve", "Carey"},
        };

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
        [MemberData(nameof(ValidUserData))]
        public void CreateNewUser_ShouldNotExceedMaxLength(int userId, string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            Assert.True(newUser.Username.Length > 5);
            Assert.True(newUser.FirstName.Length > 1);
            Assert.True(newUser.LastName.Length > 1);
        }

        [Theory]
        [MemberData(nameof(ValidUserData))]
        public void CreateNewUser_ShouldWork(int userId, string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            Assert.True(userControl.CreateNewUser(newUser));
        }

        [Theory]
        [MemberData(nameof(InvalidUserData))]
        public void CreateNewUser_ShouldNotAcceptEmptyValues(string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            Assert.False(userControl.CreateNewUser(newUser));
        }

        [Fact]
        public void RetrieveUser_ShouldReturnList()
        {
            userList = userControl.RetrieveUser();
            Assert.NotEmpty(userRepo.GetUserList());
        }

        [Theory]
        [MemberData(nameof(ValidUserData))]
        public void UpdateUser_ShouldWork(int userId, string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            //bool expected = userControl.IsUserExist(newUser);
            //bool actual = isUserExist;

            //Assert.Equal(expected, actual);
            Assert.True(userControl.UpdateUser(newUser));
        }

        [Theory]
        [InlineData(5, "Myelxx", "Password101", "Mel", "Meji" )]
        public void UpdateUser_ShouldFail(int userId, string userName, string password, string firstName, string lastName)
        {
            User newUser = new User { UserId = userId, Username = userName, Password = password, FirstName = firstName, LastName = lastName };
            //bool expected = userControl.IsUserExist(newUser);
            //bool actual = isUserExist;

            //Assert.NotEqual(expected, actual);
            Assert.False(userControl.UpdateUser(newUser));
        }

        [Theory]
        [InlineData(2)] //valid
        public void DeleteUser_ShouldWork(int userId)
        {
            User newUser = new User { UserId = userId };
            //bool actual = userControl.IsUserExist(newUser);
            //bool expected = isUserExist;

            //Assert.NotEqual(expected, actual);
            Assert.True(userControl.DeleteUser(newUser));
        }

        [Theory]
        [InlineData(3)] 

        public void DeleteUser_ShouldFail(int userId)
        {
            User newUser = new User { UserId = userId };
            //bool actual = userControl.IsUserExist(newUser);
            //bool expected = isUserExist;

            //Assert.NotEqual(expected, actual);
            Assert.False(userControl.DeleteUser(newUser));
        }

    }
}
