using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.DAL.Models
{
    public class Book
    {
        public Book()
        {
            ReaderBooks = new List<ReaderBook>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public virtual ICollection<ReaderBook> ReaderBooks { get; set; }
    }
}
