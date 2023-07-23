using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IRepository;
using Core.Management;
using Core.Models;

namespace Core.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByEmail(string email) => UserManagement.Instance.GetUserByEmail(email);


        public User GetUserByName(string userName) => UserManagement.Instance.GetUserByUserName(userName);

        public void Insert(User user) => UserManagement.Instance.AddUser(user);


    }
}
