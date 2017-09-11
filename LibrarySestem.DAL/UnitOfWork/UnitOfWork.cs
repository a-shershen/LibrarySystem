using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.DAL.Interfaces;
using LibrarySestem.DAL.Models;

namespace LibrarySestem.DAL.UnitOfWork
{
    public class UnitOfWork : Interfaces.IUnitOfWork, IDisposable
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
