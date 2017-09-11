using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.BLL.DTOModels;

using LibrarySestem.BLL.Mappers;

namespace LibrarySestem.BLL.Services
{
    public class BookService : Interfaces.IBookService
    {
        private DAL.Interfaces.IUnitOfWork db;

        public BookService(DAL.Interfaces.IUnitOfWork iUow)
        {
            db = iUow;
        }

        public void AddNewBook(BookDTO book)
        {
            db.Books.Add(book.ToDal());
            db.Save();
        }

        public void DeleteBoo(int bookId)
        {
            db.Books.Delete(b => b.Id == bookId);
            db.Save();
        }

        public BookDTO GetBook(int bookId)
        {
            return db.Books.Get(b => b.Id == bookId).ToDto();
        }

        public void UpdateBook(BookDTO book)
        {
            db.Books.Update(book.ToDal());
            db.Save();
        }
    }
}
