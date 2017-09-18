using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.BLL.DTOModels;

using LibrarySestem.BLL.Mappers;

namespace LibrarySestem.BLL.Services
{
    public class LibraryService:Interfaces.ILibraryService
    {
        private DAL.Interfaces.IUnitOfWork db;

        public LibraryService(DAL.Interfaces.IUnitOfWork iUow)
        {
            db = iUow;
        }

        public IEnumerable<ReaderBookInfo> GetAllBooks()
        {
            return db.ReaderBooks.GetAllInfo().ToDto();
        }

        public IEnumerable<ReaderBookInfo> GetAllNotReturnedUserBooks()
        {
            return db.ReaderBooks.GetAllInfo(rb => rb.IsReturned == false).OrderBy(o=>o.TakeTime).ToDto();
        }

        public IEnumerable<ReaderBookInfo> GetAllNotReturnedUserBooks(int userId)
        {
            return db.ReaderBooks.GetAllInfo(rb => rb.ReaderId == userId && rb.IsReturned == false).ToDto();
        }

        public IEnumerable<ReaderBookInfo> GetAllUserBooks(int userId)
        {
            return db.ReaderBooks.GetAllInfo(rb => rb.ReaderId == userId).OrderBy(r => r.IsReturned).ToDto();
        }

        public void GiveBookForUser(int userId, int bookId)
        {
            var book = db.Books.Get(b => b.Id == bookId);

            var user = db.Users.Get(u => u.Id == userId);

            if(book!=null && user != null)
            {
                db.ReaderBooks.Add(
                    new DAL.Models.ReaderBook
                    {
                        BackTime = null,
                        BookId = bookId,
                        IsReturned = false,
                        ReaderId = userId,
                        TakeTime = DateTime.Now
                    }
                    );
            }
        }

        public void ReturnBook(int UserId, int bookId)
        {
            var record = db.ReaderBooks.Get(rb => rb.ReaderId == UserId && rb.BookId == bookId);

            if (record != null)
            {
                record.IsReturned = true;
                record.BackTime = DateTime.Now;

                db.ReaderBooks.Update(record);
            }
        }
    }
}
