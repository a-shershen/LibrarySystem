using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.DAL.ExtendedModels;
using LibrarySestem.DAL.Interfaces;
using LibrarySestem.DAL.Models;

namespace LibrarySestem.DAL.Repositories
{
    class ReaderBookRepo:Interfaces.IReaderBookInfo
    {
        private DBContext.CustomContext db;

        public ReaderBookRepo(DBContext.CustomContext db)
        {
            this.db = db;
        }

        public void Add(ReaderBook item)
        {
            db.ReaderBooks.Add(item);
        }

        public void Delete(Func<ReaderBook, bool> predicate)
        {
            var rb = Get(predicate);

            if(rb!=null)
            {
                db.ReaderBooks.Remove(rb);
            }
        }

        public ReaderBook Get(Func<ReaderBook, bool> predicate)
        {
            return db.ReaderBooks.FirstOrDefault(predicate);
        }

        public IEnumerable<ReaderBook> GetAll(Func<ReaderBook, bool> predicate = null)
        {
            if(predicate!=null)
            {
                return db.ReaderBooks.Where(predicate);
            }
            else
            {
                return db.ReaderBooks.AsEnumerable();
            }
        }

        public IEnumerable<ReaderBookInfo> GetAllInfo(Func<ReaderBook, bool> predicate = null)
        {
            if (predicate != null)
            {
                return db.ReaderBooks.Where(predicate).Join(db.Books, rb => rb.BookId, b => b.Id, (rb, b) => new { rb, b })
                    .Join(db.Readers, rbb => rbb.rb.ReaderId, r => r.Id,
                    (rbb, r) => new ReaderBookInfo
                    {
                        Id = rbb.rb.Id,
                        Author = rbb.b.Author,
                        BackTime = rbb.rb.BackTime,
                        BirthDate = r.BirthDate,
                        BookId = rbb.b.Id,
                        FirstName = r.FirstName,
                        IsReturned = rbb.rb.IsReturned,
                        LastName = r.LastName,
                        ReaderId = r.Id,
                        TakeTime = rbb.rb.TakeTime,
                        Title = rbb.b.Title,
                        Year = rbb.b.Year
                    });
            }

            else
            {
                return db.Books.Join(db.ReaderBooks, b => b.Id, rb => rb.BookId, (b, rb) => new { b, rb })
                    .Join(db.Readers, brb => brb.rb.ReaderId, r => r.Id,
                    (brb, r) => new ReaderBookInfo
                    {
                        Id = brb.rb.Id,
                        Author = brb.b.Author,
                        BackTime = brb.rb.BackTime,
                        BirthDate = r.BirthDate,
                        BookId = brb.b.Id,
                        FirstName = r.FirstName,
                        IsReturned = brb.rb.IsReturned,
                        LastName = r.LastName,
                        ReaderId = r.Id,
                        TakeTime = brb.rb.TakeTime,
                        Title = brb.b.Title,
                        Year = brb.b.Year
                    });
            }
        }

        public void Update(ReaderBook item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
