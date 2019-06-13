using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MoqUserControl
    {
        UserRepo userRepo = new UserRepo();

        //MOQ
        IRepository repository;
        public MoqUserControl(IRepository repository)
        {
            this.repository = repository;
        }

        public void CreateNewUser(User user)
        {
            userRepo.AddToList(user);

        }
        public void DisplayUserList()
        {
            var userList = repository.GetUserList();
            foreach (var user in userList)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
