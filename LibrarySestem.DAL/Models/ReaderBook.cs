using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySestem.DAL.Models
{
    public class ReaderBook
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public DateTime TakeTime { get; set; }

        public DateTime? BackTime { get; set; }

        public bool IsReturned { get; set; }

        [ForeignKey("ReaderId")]
        public virtual Reader Reader { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
