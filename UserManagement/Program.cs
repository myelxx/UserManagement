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
            UserRepo userrepo = new UserRepo();
            userrepo.GetUserList();

        }
    }
}
