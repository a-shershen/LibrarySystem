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

        public static Models.LibraryRecord ToView(this BLL.DTOModels.ReaderBookInfo info)
        {
            return new Models.LibraryRecord
            {
                Id = info.Id,
                Author = info.Author,
                BackTime = info.BackTime,
                BirthDate = info.BirthDate,
                BookId = info.BookId,
                FirstName = info.FirstName,
                IsReturned = info.IsReturned,
                LastName = info.LastName,
                ReaderId = info.ReaderId,
                TakeTime = info.TakeTime,
                Title = info.Title,
                Year = info.Year
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

        public static IEnumerable<Models.LibraryRecord> ToView(this IEnumerable<BLL.DTOModels.ReaderBookInfo> infos)
        {
            List<Models.LibraryRecord> records = new List<Models.LibraryRecord>();

            foreach(var i in infos)
            {
                records.Add(i.ToView());
            }

            return records.AsEnumerable();
        }
    }
}