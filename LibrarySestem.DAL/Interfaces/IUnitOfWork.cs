using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<Models.Book> Books { get; }
        IGenericRepo<Models.Reader> Readers { get; }
        IReaderBookInfo ReaderBooks { get; }
        IGenericRepo<Models.User> Users { get; }
        void Save();
    }
}
