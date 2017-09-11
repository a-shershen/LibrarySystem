using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<DTOModels.BookDTO> SearchByAuthor(string author);

        IEnumerable<DTOModels.BookDTO> SearchByName(string bookName);
    }
}
