using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User
    {
        //public User(string username="", string firstname="", string lastname="")
        //{
        //    Username = username;
        //    FirstName = firstname;
        //    LastName = lastname;
        //}

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Created_At { get; set; }
    }
}
