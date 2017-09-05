using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.DAL.Models;

namespace LibrarySestem.DAL.Repositories
{
    class UserRepo : Interfaces.IGenericRepo<Models.User>
    {
        private DBContext.CustomContext db;

        public UserRepo(DBContext.CustomContext db)
        {
            this.db = db;
        }

        public void Add(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(Func<User, bool> predicate)
        {
            var user = Get(predicate);

            if(user!=null)
            {
                db.Users.Remove(user);
            }
        }

        public User Get(Func<User, bool> predicate)
        {
            return db.Users.FirstOrDefault(predicate);
        }

        public IEnumerable<User> GetAll(Func<User, bool> predicate = null)
        {
            if(predicate!=null)
            {
                return db.Users.Where(predicate);
            }
            else
            {
                return db.Users.AsEnumerable();
            }
        }

        public void Update(User item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
