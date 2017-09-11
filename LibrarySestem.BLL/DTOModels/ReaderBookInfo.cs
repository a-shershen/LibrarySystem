using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.DTOModels
{
    public class ReaderBookInfo
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public DateTime TakeTime { get; set; }

        public DateTime? BackTime { get; set; }

        public bool IsReturned { get; set; }
    }
}
