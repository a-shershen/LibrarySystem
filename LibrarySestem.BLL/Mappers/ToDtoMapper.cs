using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Mappers
{
    public static class ToDtoMapper
    {
        public static DTOModels.BookDTO ToDto(this DAL.Models.Book book)
        {
            return new DTOModels.BookDTO
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Year = book.Year
            };
        }

        public static DTOModels.ReaderDTO ToDto(this DAL.Models.Reader reader)
        {
            return new DTOModels.ReaderDTO
            {
                Id = reader.Id,
                BirthDate = reader.BirthDate,
                FirstName = reader.FirstName,
                LastName = reader.LastName
            };
        }

        public static DTOModels.ReaderBookInfo ToDto(this DAL.ExtendedModels.ReaderBookInfo info)
        {
            return new DTOModels.ReaderBookInfo
            {
                Author = info.Author,
                BackTime = info.BackTime,
                BirthDate = info.BirthDate,
                BookId = info.BookId,
                FirstName = info.FirstName,
                Id = info.Id,
                IsReturned = info.IsReturned,
                LastName = info.LastName,
                ReaderId = info.ReaderId,
                TakeTime = info.TakeTime,
                Title = info.Title,
                Year = info.Year
            };
        }
        public static IEnumerable<DTOModels.BookDTO> ToDto(this IEnumerable<DAL.Models.Book> books)
        {
            List<DTOModels.BookDTO> dtoBooks = new List<DTOModels.BookDTO>();

            foreach(var book in books)
            {
                dtoBooks.Add(book.ToDto());
            }

            return dtoBooks.AsEnumerable();
        }

        public static IEnumerable<DTOModels.ReaderBookInfo> ToDto(this IEnumerable<DAL.ExtendedModels.ReaderBookInfo> list)
        {
            List<DTOModels.ReaderBookInfo> resultList = new List<DTOModels.ReaderBookInfo>();

            foreach(var item in list)
            {
                resultList.Add(item.ToDto());
            }

            return resultList.AsEnumerable();
        }

        public static IEnumerable<DTOModels.ReaderDTO> ToDto(this IEnumerable<DAL.Models.Reader> readers)
        {
            List<DTOModels.ReaderDTO> dtoReaders = new List<DTOModels.ReaderDTO>();

            foreach(var r in readers)
            {
                dtoReaders.Add(r.ToDto());
            }

            return dtoReaders.AsEnumerable();
        }
    }
}
