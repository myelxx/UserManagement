using System;
using System.Collections.Generic;
using Business;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using Xunit;

namespace MoqBusinessTest
{
    [TestClass]
    public class MoqUserControlTest
    {

        [TestMethod]
        public void MockTest_CreateNewUser()
        {
            List<User> userList = new List<User>();
            User user = new User()
            {
                UserId = 7,
                Username = "zariyah",
                Password = "Password123",
                FirstName = "Zari",
                LastName = "Leviste"
            };

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(r => r.AddToList(user));
            var userControl = new MoqUserControl(mockRepo.Object);
            userControl.CreateNewUser(user);
        }

        //[TestMethod]
        //public void DisplayUserList()
        //{
        //    List<User> userList = new List<User>();
        //    Mock<IRepository> mockRepo = new Mock<IRepository>();

        //    mockRepo.Setup(r => r.GetUserList()).Returns(userList);
        //    var userControl = new MoqUserControl(mockRepo.Object);

        //    userControl.DisplayUserList();
        //}
    }
}
