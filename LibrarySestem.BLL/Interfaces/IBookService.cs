using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Interfaces
{
    public interface IBookService
    {
        void AddNewBook(DTOModels.BookDTO book);

        DTOModels.BookDTO GetBook(int bookId);

        void UpdateBook(DTOModels.BookDTO book);

        void DeleteBook(int bookId);

        IEnumerable<DTOModels.BookDTO> GetAllBooks();
    }
}
