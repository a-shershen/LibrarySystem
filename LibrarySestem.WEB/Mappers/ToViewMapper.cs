using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySestem.WEB.Mappers
{
    public static class ToViewMapper
    {
        public static Models.BookViewModel ToView(this BLL.DTOModels.BookDTO book)
        {
            return new Models.BookViewModel
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Year = book.Year
            };
        }

        public static Models.Reader ToView(this BLL.DTOModels.ReaderDTO reader)
        {
            return new Models.Reader
            {
                Id = reader.Id,
                BirthDate = reader.BirthDate,
                FirstName = reader.FirstName,
                LastName = reader.LastName
            };
        }

        public static IEnumerable<Models.BookViewModel> ToView(this IEnumerable<BLL.DTOModels.BookDTO> books)
        {
            List<Models.BookViewModel> viewBooks = new List<Models.BookViewModel>();

            foreach(var book in books)
            {
                viewBooks.Add(book.ToView());
            }

            return viewBooks.AsEnumerable();
        }

        public static IEnumerable<Models.Reader> ToView(this IEnumerable<BLL.DTOModels.ReaderDTO> dtoReaders)
        {
            List<Models.Reader> viewReaders = new List<Models.Reader>();

            foreach (var r in dtoReaders)
            {
                viewReaders.Add(r.ToView());
            }

            return viewReaders.AsEnumerable();
        }
    }
}