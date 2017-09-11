using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Services
{
    public class AccountService : Interfaces.IAccountService
    {
        private DAL.Interfaces.IUnitOfWork db;

        public AccountService(DAL.Interfaces.IUnitOfWork iUow)
        {
            db = iUow;
        }

        public bool IsPasswordTrue(string login, string password)
        {
            var user = db.Users.Get(u => u.Login == login && u.Password == Hashing.Sha2Hash.GetHash(password, true));

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
