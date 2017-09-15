using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySestem.WEB.Mappers
{
    public static class ToBllModel
    {
        public static BLL.DTOModels.BookDTO ToDto(this WEB.Models.AddBookModel book)
        {
            return new BLL.DTOModels.BookDTO
            {
                Author = book.Author,
                Title = book.Title,
                Year = book.Year
            };
        }

        public static BLL.DTOModels.ReaderDTO ToDto(this Models.AddNewReader reader)
        {
            return new BLL.DTOModels.ReaderDTO
            {
                BirthDate = reader.BirthDate,
                FirstName = reader.FirstName,
                LastName = reader.LastName
            };
        }
    }
}