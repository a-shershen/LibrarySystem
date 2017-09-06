using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.DAL.Interfaces;
using LibrarySestem.DAL.Models;

namespace LibrarySestem.DAL.UnitOfWork
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        private DBContext.CustomContext db;

        public UnitOfWork(string connString)
        {
            db = new DBContext.CustomContext(connString);
        }

        private IGenericRepo<Book> bookRepo;
        private IGenericRepo<Reader> readerRepo;
        private IReaderBookInfo readerBookRepo;
        private IGenericRepo<User> userRepo;

        public IGenericRepo<Book> Books
        {
            get
            {
                if (bookRepo == null)
                {
                    bookRepo = new Repositories.BookRepo(db);
                }

                return bookRepo;
            }
        }

        public IGenericRepo<Reader> Readers
        {
            get
            {
                if(readerRepo==null)
                {
                    readerRepo = new Repositories.ReaderRepo(db);
                }

                return readerRepo;
            }
        }

        public IReaderBookInfo ReaderBooks
        {
            get
            {
                if(readerBookRepo==null)
                {
                    readerBookRepo = new Repositories.ReaderBookRepo(db);
                }

                return readerBookRepo;
            }
        }

        public IGenericRepo<User> Users
        {
            get
            {
                if(userRepo==null)
                {
                    userRepo = new Repositories.UserRepo(db);
                }

                return userRepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
