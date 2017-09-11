using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.BLL.DTOModels;
using LibrarySestem.BLL.Mappers;

namespace LibrarySestem.BLL.Services
{
    public class SearchService:Interfaces.ISearchService
    {
        private DAL.Interfaces.IUnitOfWork db;

        public SearchService(DAL.Interfaces.IUnitOfWork iUow)
        {
            db = iUow;
        }

        public IEnumerable<BookDTO> SearchByAuthor(string author)
        {
            return db.Books.GetAll(b => b.Author.Contains(author)).Distinct().ToDto();
        }

        public IEnumerable<BookDTO> SearchByName(string bookName)
        {
            return db.Books.GetAll(b => b.Title.Contains(bookName)).Distinct().ToDto();
        }
    }
}
