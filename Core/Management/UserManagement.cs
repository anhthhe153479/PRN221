using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Management
{
    public class UserManagement
    {
        private static UserManagement instance;
        private static readonly object instanceLock = new object();
        private UserManagement() { }
        public static UserManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserManagement();
                    }
                    return instance;
                }

            }
        }
        public User GetUserByUserName(string userName)
        {
            User user = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                user = managerDB.Users.SingleOrDefault(user => user.UserName.Equals(userName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                user = managerDB.Users.SingleOrDefault(user => user.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                try
                {

                    var managerDB = new Management_System_ProjectContext();
                    managerDB.Users.Add(user);
                    managerDB.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);

                    throw new Exception(ex.Message);

                }
            }
        }

    }
}
