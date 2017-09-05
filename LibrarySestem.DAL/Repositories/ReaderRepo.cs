using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.DAL.Models;

namespace LibrarySestem.DAL.Repositories
{
    class ReaderRepo : Interfaces.IGenericRepo<Models.Reader>
    {
        private DBContext.CustomContext db;

        public ReaderRepo(DBContext.CustomContext db)
        {
            this.db = db;
        }
        public void Add(Reader item)
        {
            db.Readers.Add(item);
        }

        public void Delete(Func<Reader, bool> predicate)
        {
            var reader = Get(predicate);

            if(reader!=null)
            {
                db.Readers.Remove(reader);
            }
        }

        public Reader Get(Func<Reader, bool> predicate)
        {
            return db.Readers.FirstOrDefault(predicate);
        }

        public IEnumerable<Reader> GetAll(Func<Reader, bool> predicate = null)
        {
            if(predicate!=null)
            {
                return db.Readers.Where(predicate);
            }
            else
            {
                return db.Readers.AsEnumerable();
            }
        }

        public void Update(Reader item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
