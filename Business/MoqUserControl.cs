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

        IRepository repository;
        public MoqUserControl(IRepository repository)
        {
            this.repository = repository;
        }

        public void CreateNewUser(User user)
        {
            repository.AddToList(user);
        }

        //public List<User> DisplayUserList()
        //{
        //    var userList = repository.GetUserList();
        //    return userList;
        //}
    }
}
