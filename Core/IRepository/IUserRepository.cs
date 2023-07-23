using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.IRepository
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);
        User GetUserByEmail(string email);
        void Insert(User user);
    }
}
