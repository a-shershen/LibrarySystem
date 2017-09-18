using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Interfaces
{
    public interface ILibraryService
    {
        void GiveBookForUser(int userId, int bookId);

        void ReturnBook(int UserId, int bookId);

        IEnumerable<DTOModels.ReaderBookInfo> GetAllBooks();

        IEnumerable<DTOModels.ReaderBookInfo> GetAllUserBooks(int userId);

        IEnumerable<DTOModels.ReaderBookInfo> GetAllNotReturnedUserBooks();

        IEnumerable<DTOModels.ReaderBookInfo> GetAllNotReturnedUserBooks(int userId);
    }
}
