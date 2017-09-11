using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Mappers
{
    public static class ToDalMapper
    {
        public static DAL.Models.Book ToDal(this DTOModels.BookDTO book)
        {
            return new DAL.Models.Book
            {
                Id=book.Id,
                Author = book.Author,
                Title = book.Title,
                Year = book.Year
            };
        }

        public static DAL.Models.Reader ToDal(this DTOModels.ReaderDTO reader)
        {
            return new DAL.Models.Reader
            {
                Id = reader.Id,
                BirthDate = reader.BirthDate,
                FirstName = reader.FirstName,
                LastName = reader.LastName
            };
        }
    }
}
