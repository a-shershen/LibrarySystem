using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.DAL.Models;

namespace LibrarySestem.DAL.Repositories
{
    class BookRepo : Interfaces.IGenericRepo<Models.Book>
    {
        private DBContext.CustomContext db;

        public BookRepo(DBContext.CustomContext db)
        {
            this.db = db;
        }

        public void Add(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(Func<Book, bool> predicate)
        {
            var book = Get(predicate);

            if(book!=null)
            {
                db.Books.Remove(book);
            }
        }

        public Book Get(Func<Book, bool> predicate)
        {
            return db.Books.FirstOrDefault(predicate);
        }

        public IEnumerable<Book> GetAll(Func<Book, bool> predicate = null)
        {
            if(predicate!=null)
            {
                return db.Books.Where(predicate);
            }

            else
            {
                return db.Books.AsEnumerable();
            }
        }

        public void Update(Book item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
