using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.DAL.Models
{
    public class Reader
    {
        public Reader()
        {
            ReaderBooks = new List<ReaderBook>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<ReaderBook> ReaderBooks { get; set; }
    }
}
